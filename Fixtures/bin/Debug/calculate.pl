%Teams + their parameters are asserted using C#
%....
%team(TeamA)
%sharedGrounds(TeamA, TeamB)
%home(TeamA, Week)
%noPlay(TeamA, Week)
%division(d1)
%inDivision(TeamA, Division)

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
week(h1).
week(h2).
week(h3).

away(Team, Week):-
    team(Team),
    week(Week),
    not(home(Team, Week)).