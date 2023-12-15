Module Module1
    'A. Russell
    '12/12-13/23
    'Rock Paper Scissors

    'Variables
    Private rand As New Random
    Dim round As Integer = 1
    Dim maxRounds(4) As Integer
    Sub Main()
        Dim Umove, Cmove As Integer
        Dim userOutcome, Uname, Cname As String
        Dim roundnum(maxRounds.Length), user(maxRounds.Length), comp(maxRounds.Length), ending(maxRounds.Length) As String
        PrintTitle()
        For i As Integer = 0 To maxRounds.Length - 1
            Console.WriteLine($"Round {round}")
            Umove = ValidInput()
            Uname = ConvertNumToWord(Umove)
            Cmove = CompMove()
            Cname = ConvertNumToWord(Cmove)
            userOutcome = Outcome(Umove, Cmove)
            Console.WriteLine($"You played {Uname}. The computer played {Cname}")
            Console.WriteLine(userOutcome & vbNewLine)
            roundnum(i) = round.ToString
            user(i) = Uname
            comp(i) = Cname
            ending(i) = userOutcome
            round += 1
        Next
        PrintReport(roundnum, user, comp, ending)
    End Sub

    'Subs
    ''' <summary>
    ''' Prints out a line of report
    ''' </summary>
    Sub PrintReportLine(str1 As String, str2 As String, str3 As String, str4 As String)
        Console.WriteLine("| {0} | {1} | {2} | {3} |", str1.PadLeft(10), str2.PadLeft(20), str3.PadLeft(20), str4.PadLeft(10))
    End Sub
    ''' <summary>
    ''' Prints out full report
    ''' </summary>
    Sub PrintReport(round() As String, Umove() As String, Cmove() As String, userOutcome() As String)
        Console.WriteLine("".PadRight(73, "#"))
        Console.WriteLine("Paper, Rock, Scissors Report".PadLeft(20, "#").PadRight(20, "#"))
        Console.WriteLine("".PadRight(73, "#"))
        Console.WriteLine("".PadRight(73, "-"))
        PrintReportLine("Round", "User Played", "Computer Played", "Outcome")
        Console.WriteLine("".PadRight(73, "-"))
        For i As Integer = 0 To maxRounds.Length - 1
            PrintReportLine(round(i), Umove(i), Cmove(i), userOutcome(i))
            Console.WriteLine("".PadRight(73, "-"))
        Next
    End Sub
    ''' <summary>
    ''' Prints out title
    ''' </summary>
    Sub PrintTitle()
        Console.WriteLine("
.-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.
|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.
' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'
    _______           _______               _______
---'   ____)      ---'   ____)____     ---'    ____)____
        (_____)               ______)               ______)
        (_____)               _______)           __________)
        (____)               _______)           (____)
---.__(___)       ---.__________)      ---.__(___)

        ")
    End Sub


    'Functions
    ''' <summary>
    ''' Asks user for a 1, 2, or 3. If something else is given, it asks again
    ''' </summary>
    ''' <returns>The user's move</returns>
    Function ValidInput()
        Dim input As String
        Dim move As Integer
        Dim valid As Boolean
        Do
            Console.Write("Please enter a 1 for rock, 2 for paper, 3 scissors >> ")
            input = Console.ReadLine
            Integer.TryParse(input, move)
            If move > 3 OrElse move < 1 Then
                Console.WriteLine("Invalid Input")
                valid = False
            Else
                valid = True
            End If
        Loop While Not valid
        Return move
    End Function '11 - Done?
    ''' <summary>
    ''' Gets a number between 1 and 3 for the computer's move
    ''' </summary>
    ''' <returns>The computer's move</returns>
    Function CompMove()
        Dim move As Integer = rand.Next(1, 4)
        Return move
    End Function '2 - Done
    ''' <summary>
    ''' Convert's the move from the integer to it's string counterpart
    ''' </summary>
    ''' <returns>The name of the move</returns>
    Function ConvertNumToWord(move As Integer)
        Dim name() As String = {"rock", "paper", "scissors"}
        Dim moveName As String = name(move - 1)
        Return moveName
    End Function '3 - Done
    ''' <summary>
    ''' Determines whether the round was a win, loss, or tie for the user
    ''' </summary>
    ''' <returns>The outcome</returns>
    Function Outcome(Umove, Cmove)
        Dim userOutcome As String = "Unknown"
        If Umove = 1 AndAlso Cmove = 2 Then
            userOutcome = "Loss"
        ElseIf Umove = 1 AndAlso Cmove = 3 Then
            userOutcome = "Win"
        ElseIf Umove = 2 AndAlso Cmove = 3 Then
            userOutcome = "Loss"
        ElseIf Umove = 2 AndAlso Cmove = 1 Then
            userOutcome = "Win"
        ElseIf Umove = 3 AndAlso Cmove = 1 Then
            userOutcome = "Win"
        ElseIf Umove = 3 AndAlso Cmove = 2 Then
            userOutcome = "Win"
        ElseIf Umove = Cmove Then
            userOutcome = "Tie"
        End If
        Return userOutcome
    End Function '16 - Done
End Module
