%Teams + their parameters are asserted using C#
%....
%team(TeamA)
%sharedGrounds(TeamA, TeamB)
%home(TeamA, Week)
%noPlay(TeamA, Week)
%division(d1)
%inDivision(TeamA, Division)

%There are 26 weeks in the league year including 3 bank holidays
week(w1).
week(w2).
week(w3).
week(w4).
week(w5).
week(w6).
week(w7).
week(w8).
week(w9).
week(w10).
week(w11).
week(w12).
week(w13).
week(w14).
week(w15).
week(w16).
week(w17).
week(w18).
week(w19).
week(w20).
week(w21).
week(w22).
week(w23).
holiday(h1).
holiday(h2).
holiday(h3).

away(Team, Week):-
    team(Team),
    week(Week),
    not(home(Team, Week)).

%playingHome means the team *plays* at home whereas 'home' means the team must not play away 
playingHome(Team, Week):-
    team(Team),
    week(Week),
    not(playingAway(Team, Week)).

%Multiple instances of playingHome for case of shared grounds
%Shares grounds with one other team
playingHome(Team, Week):-
    team(Team),
    week(Week),
    sharedGrounds(Team, A),
    playingAway(A, Week),
    not(playingHome(A, Week)).

%Shares grounds with two other teams
playingHome(Team, Week):-
    team(Team),
    week(Week),
    sharedGrounds(Team, A),
    playingAway(A, Week),
    not(playingHome(A, Week)),
	sharedGrounds(Team, B),
    playingAway(B, Week),
    not(playingHome(B, Week)).

%Shares grounds with three other teams
playingHome(Team, Week):-
    team(Team),
    week(Week),
    sharedGrounds(Team, A),
    playingAway(A, Week),
    not(playingHome(A, Week)),
	sharedGrounds(Team, B),
    playingAway(B, Week),
    not(playingHome(B, Week)),
    sharedGrounds(Team, C),
    playingAway(C, Week),
    not(playingHome(C, Week)).

%Shares grounds with four other teams
playingHome(Team, Week):-
    team(Team),
    week(Week),
    sharedGrounds(Team, A),
    playingAway(A, Week),
    not(playingHome(A, Week)),
	sharedGrounds(Team, B),
    playingAway(B, Week),
    not(playingHome(B, Week)),
    sharedGrounds(Team, C),
    playingAway(C, Week),
    not(playingHome(C, Week)),
    sharedGrounds(Team, D),
    playingAway(D, Week),
    not(playingHome(D, Week)).

%This team plays away on this date. As opposed to 'away' which is less set in stone
playingAway(Team, Week):-
    team(Team),
    week(Week),
    not(home(Team, Week)),
    not(playingHome(Team, Week)).

%Super rule 'plays'
%Two teams in division
plays2(TeamA, TeamB, Week):-
    team(TeamA),
    team(TeamB),
    week(Week),
    inDivision(TeamA, D),
    inDivision(TeamB, D),
    division(D),
    home(TeamA, Week),
    away(TeamB, Week),
    playingHome(TeamA, Week),
    playingAway(TeamB, Week),
    not(plays2(A, B, Week)),
    plays2(TeamB, TeamA, W).

%Use holiday if cannot play any other week
plays2(TeamA, TeamB, Week):-
    team(TeamA),
    team(TeamB),
    holiday(Week),
    inDivision(TeamA, D),
    inDivision(TeamB, D),
    division(D),
    home(TeamA, Week),
    away(TeamB, Week),
    playingHome(TeamA, Week),
    playingAway(TeamB, Week),
    not(plays2(A, B, Week)),
    not(plays2(TeamA, TeamB, C)),
    week(C)
    plays2(TeamB, TeamA, W).

%Four teams in division (including potential fillerTeam)
%Two Matches played in week
Plays4(TeamA, TeamB, Week):-
    team(TeamA),
    team(TeamB),
    week(Week),
    inDivision(TeamA, D),
    inDivision(TeamB, D),
    division(D),
    home(TeamA),
    away(TeamB),
    playingHome(TeamA),
    playingAway(TeamB),
    Plays4(A, B, Week)),
    not(Plays4(X, Y, Week)),

%One match played in week
plays4(TeamA, TeamB, Week):-
    team(TeamA),
    team(TeamB),
    week(Week),
    inDivision(TeamA, D),
    inDivision(TeamB, D),
    division(D),
    home(TeamA, Week),
    away(TeamB, Week),
    playingHome(TeamA, Week),
    playingAway(TeamB, Week),
    not(plays4(A, B, Week)),
    plays4(TeamB, TeamA, W),
    plays4(TeamA, Team1, W1),
    plays4(TeamA, Team2, W2),
    plays4(Team1, TeamA, W3),
    plays4(Team2, TeamA, W4),
    plays4(TeamB, Team1, W5),
    plays4(TeamB, Team2, W6),
    plays4(Team1, TeamB, W7),
    plays4(Team2, TeamB, W8),
    plays4(Team1, Team2, W9),
    plays4(Team2, Team1, W10),
    inDivision(Team1, D),
    inDivision(Team2, D).

%Use holiday if cannot play any other week
plays4(TeamA, TeamB, Week):-
    team(TeamA),
    team(TeamB),
    holiday(Week),
    inDivision(TeamA, D),
    inDivision(TeamB, D),
    division(D),
    home(TeamA, Week),
    away(TeamB, Week),
    playingHome(TeamA, Week),
    playingAway(TeamB, Week),
    not(plays4(A, B, Week)),
    not(plays4(TeamA, TeamB, C)),
    week(C)
    plays4(TeamB, TeamA, W),
    plays4(TeamA, Team1, W1),
    plays4(TeamA, Team2, W2),
    plays4(Team1, TeamA, W3),
    plays4(Team2, TeamA, W4),
    plays4(TeamB, Team1, W5),
    plays4(TeamB, Team2, W6),
    plays4(Team1, TeamB, W7),
    plays4(Team2, TeamB, W8),
    plays4(Team1, Team2, W9),
    plays4(Team2, Team1, W10).

%Six teams in division (including potential fillerTeam)
plays6(TeamA, TeamB, Week):-
    team(TeamA),
    team(TeamB),
    week(Week),
    inDivision(TeamA, D),
    inDivision(TeamB, D),
    division(D),
    home(TeamA, Week),
    away(TeamB, Week),
    playingHome(TeamA, Week),
    playingAway(TeamB, Week),
    not(plays6(A, B, Week)),
    plays6(TeamB, TeamA, W),
    plays6(TeamA, Team1, W1),
    plays6(TeamA, Team2, W2),
    plays6(TeamA, Team3, W3),
    plays6(TeamA, Team4, W4),
    plays6(Team1, TeamA, W5),
    plays6(Team2, TeamA, W6),
    plays6(Team3, TeamA, W7),
    plays6(Team4, TeamA, W8),
    plays6(TeamB, Team1, W9),
    plays6(TeamB, Team2, W10),
    plays6(TeamB, Team3, W11),
    plays6(TeamB, Team4, W12),
    plays6(Team1, TeamB, W13),
    plays6(Team2, TeamB, W14),
    plays6(Team3, TeamB, W15),
    plays6(Team4, TeamB, W16),
    plays6(Team1, Team2, W17),
    plays6(Team1, Team3, W18),
    plays6(Team1, Team4, W19),
    plays6(Team2, Team1, W20),
    plays6(Team2, Team3, W21),
    plays6(Team2, Team4, W22).

%Use holiday if cannot play any other week
plays6(TeamA, TeamB, Week):-
    team(TeamA),
    team(TeamB),
    holiday(Week),
    inDivision(TeamA, D),
    inDivision(TeamB, D),
    division(D),
    home(TeamA, Week),
    away(TeamB, Week),
    playingHome(TeamA, Week),
    playingAway(TeamB, Week),
    not(plays6(A, B, Week)),
    not(plays6(TeamA, TeamB, C)),
    week(C)
    plays6(TeamB, TeamA, W),
    plays6(TeamA, Team1, W1),
    plays6(TeamA, Team2, W2),
    plays6(TeamA, Team3, W3),
    plays6(TeamA, Team4, W4),
    plays6(Team1, TeamA, W5),
    plays6(Team2, TeamA, W6),
    plays6(Team3, TeamA, W7),
    plays6(Team4, TeamA, W8),
    plays6(TeamB, Team1, W9),
    plays6(TeamB, Team2, W10),
    plays6(TeamB, Team3, W11),
    plays6(TeamB, Team4, W12),
    plays6(Team1, TeamB, W13),
    plays6(Team2, TeamB, W14),
    plays6(Team3, TeamB, W15),
    plays6(Team4, TeamB, W16),
    plays6(Team1, Team2, W17),
    plays6(Team1, Team3, W18),
    plays6(Team1, Team4, W19),
    plays6(Team2, Team1, W20),
    plays6(Team2, Team3, W21),
    plays6(Team2, Team4, W22).

%Eight teams in division (including potential fillerTeam)
plays8(TeamA, TeamB, Week):-
    .

%Use holiday if cannot play any other week
plays8(TeamA, TeamB, Week):-
    .

%Ten teams in division (including  potential fillerTeam) (Any more teams will make it impossible for them all to play)
plays10(TeamA, TeamB, Week):-
    .

%Use holiday if cannot play any other week
plays10(TeamA, TeamB, Week):-
    .

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%Round-Robin%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%table of allocated matches
:- dynamic(alloc_table/2).

%number playing home must be less than number playing away
forHome(T, T, X) :-
    T =< X.
forHome(I, T, X) :-
    T < X,
    T1 is T + 1,
    forHome(I, T1, X).

%teams represented by integers more than 1
check_num_input(T) :-
    integer(T),
    T > 1.

%resets the allocation table of matches
reset_allocations :-
    retractall(alloc_table(_, _)).

%check the match has not already been allocated
%empty list for once recursion is complete
check_not_allocated(_, []).
%recursively search through allocation list to see if team is allocated
check_not_allocated(T, [X | CurrentMatchesTail]) :-
    \+ alloc_table(T, X),
    \+ alloc_table(X, T),
    check_not_allocated(T, CurrentMatchesTail).

%recursively fetch match allocation
get_match_allocation(_, 0, CurrentMatches, CurrentMatches).
get_match_allocation(NumTeams, RemainingNumTeamsPerMatch, CurrentMatches, Matches) :-
    RemainingNumTeamsPerMatch > 0,
    forHome(T, 1, NumTeams),
    \+ member(T, CurrentMatches),
    check_not_allocated(T, CurrentMatches),
    append(CurrentMatches, [T], NewMatches),
    Remaining1 is RemainingNumTeamsPerMatch - 1,
    get_match_allocation(NumTeams, Remaining1, NewMatches, Matches).

%recursively store/ add matches into allocation list
store_allocation_1(_, []).
store_allocation_1(T, [X | MatchesTail]) :-
    assertz(alloc_table(T, X)),
    store_allocation_1(T, MatchesTail).

%recursively store allocation from match list
store_allocation([_]).
store_allocation([T | MatchesTail]) :-
    store_allocation_1(T, MatchesTail),
    store_allocation(MatchesTail).

%recursively check all required matches are allocated
check_plays_all(_, []).
check_plays_all(T, [X | TeamsTail]) :-
    (    alloc_table(T, X)
    ;    alloc_table(X, T)),
    check_plays_all(T, TeamsTail).

check_all_play_all([_]).
check_all_play_all([T | TeamsTail]) :-
    check_plays_all(T, TeamsTail),
    check_all_play_all(TeamsTail).

do_round_robin(NumTeams, _, T, []) :-
    T > NumTeams.
do_round_robin(NumTeams, NumTeamsPerMatch, T, [Matches | MatchesTail]) :-
    T =< NumTeams,
    get_match_allocation(NumTeams, NumTeamsPerMatch, [T], Matches),
    !,
    store_allocation(Matches),
    do_round_robin(NumTeams, NumTeamsPerMatch, T, MatchesTail).
do_round_robin(NumTeams, NumTeamsPerMatch, T, Matches) :-
    T =< NumTeams,
    T1 is T + 1,
    do_round_robin(NumTeams, NumTeamsPerMatch, T1, Matches).

round_robin(NumTeams, NumTeamsPerMatch, Matches) :-
    check_num_input(NumTeams),
    check_num_input(NumTeamsPerMatch),
    reset_allocations,
    NumTeamsPerMatch1 is NumTeamsPerMatch - 1,
    do_round_robin(NumTeams, NumTeamsPerMatch1, 1, Matches),
    findall(T, forHome(T, 1, NumTeams), Teams),
    check_all_play_all(Teams),
    !,
    reset_allocations.
round_robin(_, _, _) :-
    reset_allocations,
    fail.

write_round_robin_1([]).
write_round_robin_1([G | MatchesTail]) :-
    write(G), nl,
    write_round_robin_1(MatchesTail).

write_round_robin(NumTeams, NumTeamsPerMatch) :-
    round_robin(NumTeams, NumTeamsPerMatch, Matches),
    write_round_robin_1(Matches).

legal_round_robins_1(T, MaxTeams, _, []) :-
    T > MaxTeams.
legal_round_robins_1(T, MaxTeams, NumTeamsPerMatch, [T | LegalNumTeamsTail]) :-
    T =< MaxTeams,
    round_robin(T, NumTeamsPerMatch, _),
    !,
    write(T), write(' OK ********'), nl,
    T1 is T + 1,
    legal_round_robins_1(T1, MaxTeams, NumTeamsPerMatch, LegalNumTeamsTail).
legal_round_robins_1(T, MaxTeams, NumTeamsPerMatch, LegalNumTeams) :-
    T =< MaxTeams,
    write(T), nl,
    T1 is T + 1,
    legal_round_robins_1(T1, MaxTeams, NumTeamsPerMatch, LegalNumTeams).

legal_round_robins(MaxTeams, NumTeamsPerMatch, LegalNumTeams) :-
    check_num_input(MaxTeams),
    legal_round_robins_1(1, MaxTeams, NumTeamsPerMatch, LegalNumTeams),
    !.