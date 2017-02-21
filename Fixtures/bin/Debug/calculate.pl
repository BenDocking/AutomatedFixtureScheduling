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
    plays4(Team2, Team1, W10).

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