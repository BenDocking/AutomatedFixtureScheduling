%%%%%%%%%%%%%%%%%%%%%%%%%%%%%Round-Robin%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

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
check_num_input(T) :-
    integer(T),
    T > 1.

%resets the allocation table of matches
reset_allocations :-
    retractall(match_table(_, _)).

%check the match has not already been allocated
%empty list for once recursion is complete
check_not_allocated(_, []).
%recursively search through allocation list to see if team is allocated
check_not_allocated(T, [X | CurrentMatchesTail]) :-
    \+ match_table(T, X),
    \+ match_table(X, T),
    check_not_allocated(T, CurrentMatchesTail).

%recursively fetch match allocation
get_match_allocation(_, 0, CurrentMatches, CurrentMatches).
get_match_allocation(NumTeams, RemainingNumTeamsPerMatch, CurrentMatches, Matches) :-
    RemainingNumTeamsPerMatch > 0,
    forTeams(T, 1, NumTeams),
    \+ member(T, CurrentMatches),
    check_not_allocated(T, CurrentMatches),
    append(CurrentMatches, [T], NewMatches),
    Remaining1 is RemainingNumTeamsPerMatch - 1,
    get_match_allocation(NumTeams, Remaining1, NewMatches, Matches).

%recursively store/ add matches into allocation list
store_allocation_1(_, []).
store_allocation_1(T, [X | MatchesTail]) :-
    assertz(match_table(T, X)),
    store_allocation_1(T, MatchesTail).

%recursively store allocation from match list
store_allocation([_]).
store_allocation([T | MatchesTail]) :-
    store_allocation_1(T, MatchesTail),
    store_allocation(MatchesTail).

%recursively check all required matches are allocated
check_plays_all(_, []).
check_plays_all(T, [Team | TeamsTail]) :-
    %check head team from teams list plays next head team from remaining teams list
    (    match_table(T, Team)
    ;    match_table(Team, T)),
    check_plays_all(T, TeamsTail).

check_all_play_all([_]).
%get head team of teams list
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
    NumTeamsPerMatch1 is NumTeamsPerMatch - 1, %1
    do_round_robin(NumTeams, NumTeamsPerMatch1, 1, Matches), %(NumTeams, 1, 1, Matches_List)
    findall(T, forTeams(T, 1, NumTeams), Teams), %finds all teams from 1 .. NumTeams
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