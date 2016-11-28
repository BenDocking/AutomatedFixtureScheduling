%Teams will be asserted in C#
%There will be a lot of team...all divisions
%define the teams
%use c# for this
team(t1).
team(t2).
team(t3).
team(t4).
team(t5).
team(t6).
team(t7).
team(t8).
team(t9).
team(t10).

%for teams which share grounds (defined up to 5 teams all sharing grounds)
sharedGrounds(TeamA, TeamB):-
    team(TeamA),
    team(TeamB).
sharedGrounds(TeamA, TeamB, TeamC):-
    team(TeamA),
    team(TeamB),
    team(TeamC).
sharedGrounds(TeamA, TeamB, TeamC, TeamD):-
    team(TeamA),
    team(TeamB),
    team(TeamC),
    team(TeamD).
sharedGrounds(TeamA, TeamB, TeamC, TeamD, TeamE):-
    team(TeamA),
    team(TeamB),
    team(TeamC),
    team(TeamD),
    team(TeamE).

%in case of no shared grounds
noShared(Team):-
    team(Team),
    not(sharedGrounds(Team, A)),
    not(sharedGrounds(Team, A, B)),
    not(sharedGrounds(Team, A, B, C)),
    not(sharedGrounds(Team, A, B, C, D)).
    
%there are 26 weeks in the league year including 3 bank holidays
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
week(w24).
week(w25).
week(w26).

%define divisions
division(d1).
division(d2).
division(d3).
division(d4).
division(d5).
division(d6).
division(d7).

away(Team, Week):-
    team(Team),
    week(Week).

home(Team, Week):-
    team(Team),
    week(Week).

inDivision(Team, Division):-
    team(Team),
    division(Division).

%plays = super method, bring it all together
%method to be queried to return fixtures
plays(Division, TeamH, TeamA, Week):-
    division(Division),
    week(Week),
    home(TeamH, Week),
    away(TeamA, Week),
    inDivision(TeamH, Division),
    noShared(TeamH),
    inDivision(TeamA, Division),
    not(plays(Division, TeamH, X, Week)),
    not(plays(Division, X, TeamA, Week)),
    not(plays(Division, X, TeamH, Week)),
    not(plays(Division, TeamA, X, Week)).

plays(Division, TeamH, TeamA, Week):-
    division(Division),
    week(Week),
    home(TeamH, Week),
    away(TeamA, Week),
    inDivision(TeamH, Division),
    inDivision(TeamA, Division),
    sharedGrounds(TeamH, A),
    away(A, Week),
    not(plays(Division, TeamH, X, Week)),
    not(plays(Division, X, TeamA, Week)),
    not(plays(Division, X, TeamH, Week)),
    not(plays(Division, TeamA, X, Week)).

plays(Division, TeamH, TeamA, Week):-
    division(Division),
    week(Week),
    home(TeamH, Week),
    away(TeamA, Week),
    inDivision(TeamH, Division),
    inDivision(TeamA, Division),
    sharedGrounds(TeamH, A, B),
    away(A, Week),
    away(B, Week),
    not(plays(Division, TeamH, X, Week)),
    not(plays(Division, X, TeamA, Week)),
    not(plays(Division, X, TeamH, Week)),
    not(plays(Division, TeamA, X, Week)).

plays(Division, TeamH, TeamA, Week):-
    division(Division),
    week(Week),
    home(TeamH, Week),
    away(TeamA, Week),
    inDivision(TeamH, Division),
    inDivision(TeamA, Division),
    sharedGrounds(TeamH, A, B, C),
    away(A, Week),
    away(B, Week),
    away(C, Week),
    not(plays(Division, TeamH, X, Week)),
    not(plays(Division, X, TeamA, Week)),
    not(plays(Division, X, TeamH, Week)),
    not(plays(Division, TeamA, X, Week)).

plays(Division, TeamH, TeamA, Week):-
    division(Division),
    week(Week),
    home(TeamH, Week),
    away(TeamA, Week),
    inDivision(TeamH, Division),
    inDivision(TeamA, Division),
    sharedGrounds(TeamH, A, B, C, D),
    away(A, Week),
    away(B, Week),
    away(C, Week),
    away(D, Week),
    not(plays(Division, TeamH, X, Week)),
    not(plays(Division, X, TeamA, Week)),
    not(plays(Division, X, TeamH, Week)),
    not(plays(Division, TeamA, X, Week)).