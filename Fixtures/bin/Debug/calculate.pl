:- use_module(library(clpfd)).

%table of allocated matches
:- dynamic(match_table/2).

%get all teams from 1 .. NumTeams
forTeams(T, T, X) :-
    T =< X.
forTeams(I, T, X) :-
    T < X,
    T1 is T + 1,
    forTeams(I, T1, X).

%teams represented by integers more than 1
check_int(T) :-
    integer(T),
    T > 1.

%resets the table of matches
reset_matches :-
    retractall(match_table(_, _)).

round_robin(NumTeams, NumTeamsPerMatch, Matches) :-
    check_int(NumTeams),
    check_int(NumTeamsPerMatch),
    reset_matches,
    NumTeamsPerMatch1 is NumTeamsPerMatch - 1, %1
    perform_RR(NumTeams, NumTeamsPerMatch1, 1, Matches), %(NumTeams, 1, 1, Matches_List)
    findall(T, forTeams(T, 1, NumTeams), Teams), %finds all teams from 1 .. NumTeams
    check_Teams_play_all(Teams),
    !,
    reset_matches.
round_robin(_, _, _) :-
    reset_matches,
    fail.

%recursively fetch match list
get_matches(_, 0, CurrentMatches, CurrentMatches).
get_matches(NumTeams, RemainingNumTeamsPerMatch, CurrentMatches, Matches) :-
    RemainingNumTeamsPerMatch > 0,
    forTeams(T, 1, NumTeams),
    \+ member(T, CurrentMatches),
    not_assigned(T, CurrentMatches),
    append(CurrentMatches, [T], NewMatches),
    Remaining1 is RemainingNumTeamsPerMatch - 1,
    get_matches(NumTeams, Remaining1, NewMatches, Matches).

%recursively store/ add matches into match list
store_match_1(_, []).
store_match_1(T, [X | MatchesTail]) :-
    assertz(match_table(T, X)),
    store_match_1(T, MatchesTail).

%recursively store match in match list
store_match([_]).
store_match([T | MatchesTail]) :-
    store_match_1(T, MatchesTail),
    store_match(MatchesTail).

%check the match has not already been assigned
%empty list for once recursion is complete
not_assigned(_, []).
%recursively search through match list to see if team is assigned
not_assigned(T, [X | CurrentMatchesTail]) :-
    \+ match_table(T, X),
    \+ match_table(X, T),
    not_assigned(T, CurrentMatchesTail).

%recursively check all required matches are assigned
check_Teams_play_all([_]).
%get head team of teams list
check_Teams_play_all([T | TeamsTail]) :-
    check_plays_all(T, TeamsTail),
    check_Teams_play_all(TeamsTail).

check_plays_all(_, []).
check_plays_all(T, [Team | TeamsTail]) :-
    %check head team from teams list plays next head team from remaining teams list
    (    match_table(T, Team)
    ;    match_table(Team, T)),
    check_plays_all(T, TeamsTail).

perform_RR(NumTeams, _, T, []) :-
    T > NumTeams.
perform_RR(NumTeams, NumTeamsPerMatch, T, [Matches | MatchesTail]) :-
    T =< NumTeams,
    get_matches(NumTeams, NumTeamsPerMatch, [T], Matches),
    !,
    store_match(Matches),
    perform_RR(NumTeams, NumTeamsPerMatch, T, MatchesTail).
perform_RR(NumTeams, NumTeamsPerMatch, T, Matches) :-
    T =< NumTeams,
    T1 is T + 1,
    perform_RR(NumTeams, NumTeamsPerMatch, T1, Matches).

%Teams + their parameters are asserted using C#
%....
%team(TeamA)
%sharedGrounds(TeamA, TeamB)
%home(TeamA, Week)
%noPlay(TeamA, Week)
%division(d1)
%inDivision(TeamA, Division)

%There are 26 weeks in the league year including 3 bank holidays
%week(w1).
%week(w2).
%week(w3).
%week(w4).
%week(w5).
%week(w6).
%week(w7).
%week(w8).
%week(w9).
%week(w10).
%week(w11).
%week(w12).
%week(w13).
%week(w14).
%week(w15).
%week(w16).
%week(w17).
%week(w18).
%week(w19).
%week(w20).
%week(w21).
%week(w22).
%week(w23).
%holiday(h1).
%holiday(h2).
%holiday(h3).

%away(Team, Week):-
%    team(Team),
%    week(Week),
%    not(home(Team, Week)).

%playingHome means the team *plays* at home whereas 'home' means the team must not play away 
%playingHome(Team, Week):-
%    team(Team),
%    week(Week),
%    not(playingAway(Team, Week)).

%Multiple instances of playingHome for case of shared grounds
%Shares grounds with one other team
%playingHome(Team, Week):-
%    team(Team),
%    week(Week),
%    sharedGrounds(Team, A),
%    playingAway(A, Week),
%    not(playingHome(A, Week)).

%Shares grounds with two other teams
%playingHome(Team, Week):-
%    team(Team),
%    week(Week),
%    sharedGrounds(Team, A),
%    playingAway(A, Week),
%    not(playingHome(A, Week)),
%	sharedGrounds(Team, B),
%    playingAway(B, Week),
%    not(playingHome(B, Week)).

%Shares grounds with three other teams
%playingHome(Team, Week):-
%    team(Team),
%    week(Week),
%    sharedGrounds(Team, A),
%    playingAway(A, Week),
%    not(playingHome(A, Week)),
%	sharedGrounds(Team, B),
%    playingAway(B, Week),
%    not(playingHome(B, Week)),
%    sharedGrounds(Team, C),
%    playingAway(C, Week),
%    not(playingHome(C, Week)).

%Shares grounds with four other teams
%playingHome(Team, Week):-
%    team(Team),
%    week(Week),
%    sharedGrounds(Team, A),
%    playingAway(A, Week),
%    not(playingHome(A, Week)),
%	sharedGrounds(Team, B),
%    playingAway(B, Week),
%    not(playingHome(B, Week)),
%    sharedGrounds(Team, C),
%    playingAway(C, Week),
%    not(playingHome(C, Week)),
%    sharedGrounds(Team, D),
%    playingAway(D, Week),
%    not(playingHome(D, Week)).

%This team plays away on this date. As opposed to 'away' which is less set in stone
%playingAway(Team, Week):-
%    team(Team),
%    week(Week),
%    not(home(Team, Week)),
%    not(playingHome(Team, Week)).

%Super rule 'plays'
%Two teams in division
%plays2(TeamA, TeamB, Week):-
%    team(TeamA),
%    team(TeamB),
%    week(Week),
%    inDivision(TeamA, D),
%    inDivision(TeamB, D),
%    division(D),
%    home(TeamA, Week),
%    away(TeamB, Week),
%    playingHome(TeamA, Week),
%    playingAway(TeamB, Week),
%    not(plays2(A, B, Week)),
%    plays2(TeamB, TeamA, W).

%Use holiday if cannot play any other week
%plays2(TeamA, TeamB, Week):-
%    team(TeamA),
%    team(TeamB),
%    holiday(Week),
%    inDivision(TeamA, D),
%    inDivision(TeamB, D),
%    division(D),
%    home(TeamA, Week),
%    away(TeamB, Week),
%    playingHome(TeamA, Week),
%    playingAway(TeamB, Week),
%    not(plays2(A, B, Week)),
%    not(plays2(TeamA, TeamB, C)),
%    week(C)
%    plays2(TeamB, TeamA, W).

%Four teams in division (including potential fillerTeam)
%Two Matches played in week
%Plays4(TeamA, TeamB, Week):-
%    team(TeamA),
%    team(TeamB),
%    week(Week),
%    inDivision(TeamA, D),
%    inDivision(TeamB, D),
%    division(D),
%    home(TeamA),
%    away(TeamB),
%    playingHome(TeamA),
%    playingAway(TeamB),
%    Plays4(A, B, Week)),
%    not(Plays4(X, Y, Week)),

%One match played in week
%plays4(TeamA, TeamB, Week):-
%    team(TeamA),
%    team(TeamB),
%    week(Week),
%    inDivision(TeamA, D),
%    inDivision(TeamB, D),
%    division(D),
%    home(TeamA, Week),
%    away(TeamB, Week),
%    playingHome(TeamA, Week),
%    playingAway(TeamB, Week),
%    not(plays4(A, B, Week)),
%    plays4(TeamB, TeamA, W),
%    plays4(TeamA, Team1, W1),
%    plays4(TeamA, Team2, W2),
%    plays4(Team1, TeamA, W3),
%    plays4(Team2, TeamA, W4),
%    plays4(TeamB, Team1, W5),
%    plays4(TeamB, Team2, W6),
%    plays4(Team1, TeamB, W7),
%    plays4(Team2, TeamB, W8),
%    plays4(Team1, Team2, W9),
%    plays4(Team2, Team1, W10),
%    inDivision(Team1, D),
%    inDivision(Team2, D).

%Use holiday if cannot play any other week
%plays4(TeamA, TeamB, Week):-
%    team(TeamA),
%    team(TeamB),
%    holiday(Week),
%    inDivision(TeamA, D),
%    inDivision(TeamB, D),
%    division(D),
%    home(TeamA, Week),
%    away(TeamB, Week),
%    playingHome(TeamA, Week),
%    playingAway(TeamB, Week),
%    not(plays4(A, B, Week)),
%    not(plays4(TeamA, TeamB, C)),
%    week(C)
%    plays4(TeamB, TeamA, W),
%    plays4(TeamA, Team1, W1),
%    plays4(TeamA, Team2, W2),
%    plays4(Team1, TeamA, W3),
%    plays4(Team2, TeamA, W4),
%    plays4(TeamB, Team1, W5),
%    plays4(TeamB, Team2, W6),
%    plays4(Team1, TeamB, W7),
%    plays4(Team2, TeamB, W8),
%    plays4(Team1, Team2, W9),
%    plays4(Team2, Team1, W10).

%Six teams in division (including potential fillerTeam)
%plays6(TeamA, TeamB, Week):-
%    team(TeamA),
%    team(TeamB),
%    week(Week),
%    inDivision(TeamA, D),
%    inDivision(TeamB, D),
%    division(D),
%    home(TeamA, Week),
%    away(TeamB, Week),
%    playingHome(TeamA, Week),
%    playingAway(TeamB, Week),
%    not(plays6(A, B, Week)),
%    plays6(TeamB, TeamA, W),
%    plays6(TeamA, Team1, W1),
%    plays6(TeamA, Team2, W2),
%    plays6(TeamA, Team3, W3),
%    plays6(TeamA, Team4, W4),
%    plays6(Team1, TeamA, W5),
%    plays6(Team2, TeamA, W6),
%    plays6(Team3, TeamA, W7),
%    plays6(Team4, TeamA, W8),
%    plays6(TeamB, Team1, W9),
%    plays6(TeamB, Team2, W10),
%    plays6(TeamB, Team3, W11),
%    plays6(TeamB, Team4, W12),
%    plays6(Team1, TeamB, W13),
%    plays6(Team2, TeamB, W14),
%    plays6(Team3, TeamB, W15),
%    plays6(Team4, TeamB, W16),
%    plays6(Team1, Team2, W17),
%    plays6(Team1, Team3, W18),
%    plays6(Team1, Team4, W19),
%    plays6(Team2, Team1, W20),
%    plays6(Team2, Team3, W21),
%    plays6(Team2, Team4, W22).

%Use holiday if cannot play any other week
%plays6(TeamA, TeamB, Week):-
%    team(TeamA),
%    team(TeamB),
%    holiday(Week),
%    inDivision(TeamA, D),
%    inDivision(TeamB, D),
%    division(D),
%    home(TeamA, Week),
%    away(TeamB, Week),
%    playingHome(TeamA, Week),
%    playingAway(TeamB, Week),
%    not(plays6(A, B, Week)),
%    not(plays6(TeamA, TeamB, C)),
%    week(C)
%    plays6(TeamB, TeamA, W),
%    plays6(TeamA, Team1, W1),
%    plays6(TeamA, Team2, W2),
%    plays6(TeamA, Team3, W3),
%    plays6(TeamA, Team4, W4),
%    plays6(Team1, TeamA, W5),
%    plays6(Team2, TeamA, W6),
%    plays6(Team3, TeamA, W7),
%    plays6(Team4, TeamA, W8),
%    plays6(TeamB, Team1, W9),
%    plays6(TeamB, Team2, W10),
%    plays6(TeamB, Team3, W11),
%    plays6(TeamB, Team4, W12),
%    plays6(Team1, TeamB, W13),
%    plays6(Team2, TeamB, W14),
%    plays6(Team3, TeamB, W15),
%    plays6(Team4, TeamB, W16),
%    plays6(Team1, Team2, W17),
%    plays6(Team1, Team3, W18),
%    plays6(Team1, Team4, W19),
%    plays6(Team2, Team1, W20),
%    plays6(Team2, Team3, W21),
%    plays6(Team2, Team4, W22).