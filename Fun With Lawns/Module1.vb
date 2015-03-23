Module Module1
    Class cCompany
        Public business As String
        Public name As String
        Public number As String
        Public address As String
        Public Rate As Single
        Public TotalHours As Integer
        Public totalIncome As Single
    End Class
    Class Client
        Public Name As String
        Public Address As String
        Public Phone As Integer
        Public Dates As Date
        Public time As Date

        Public Complete As Boolean
    End Class
    Dim company As New cCompany
    'Dim completedClients As New List(Of Client)
    Dim clients As New List(Of Client)
    Sub loadCompany()

        'Check if the file exists
        If IO.File.Exists("CompanyData.txt") Then


            FileOpen(1, "CompanyData.txt", OpenMode.Input)
            'while we are not end of file

            company.business = LineInput(1)
            company.name = LineInput(1)
            company.address = LineInput(1)
            company.number = LineInput(1)
            company.Rate = LineInput(1)
            company.TotalHours = LineInput(1)
            company.totalIncome = LineInput(1)




            'Close our file
            FileClose(1)
        End If


        If IO.File.Exists("ClientsData.txt") Then

            FileOpen(1, "ClientsData.txt", OpenMode.Input)

            While Not EOF(1)
                Dim newclient As New Client
                
                newclient.Name = LineInput(1)
                newclient.Address = LineInput(1)
                newclient.Phone = LineInput(1)
                newclient.Dates = LineInput(1)
                newclient.time = LineInput(1)
                    'PrintLine(1, clients(i).Complete)

                clients.Add(newclient)
            End While
            FileClose(1)
        End If
    End Sub
    Sub saveCompany()
        FileOpen(1, "CompanyData.txt", OpenMode.Output)

        PrintLine(1, company.business)
        PrintLine(1, company.name)
        PrintLine(1, company.address)
        PrintLine(1, company.number)
        PrintLine(1, company.Rate)
        PrintLine(1, company.TotalHours)
        PrintLine(1, company.totalIncome)

        FileClose(1)



        FileOpen(1, "ClientsData.txt", OpenMode.Output)

        For i = 0 To clients.Count - 1
            PrintLine(1, clients(i).Name)
            PrintLine(1, clients(i).Address)
            PrintLine(1, clients(i).Phone)
            PrintLine(1, clients(i).Dates)
            PrintLine(1, clients(i).time)
            'PrintLine(1, clients(i).Complete)
        Next
        FileClose(1)
    End Sub
    Sub CompanyInfo()
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Welcome " & company.name)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("═════════════════════════════════════════════════════════════")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Total completed hours: " & company.TotalHours)
        Console.WriteLine("Total income : " & FormatCurrency(company.totalIncome))
        Console.WriteLine("Hourly rate: " & FormatCurrency(company.Rate))
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("═════════════════════════════════════════════════════════════")

    End Sub
    Function GetBookings(complete As Boolean)
        Console.Clear()
        Dim index As Integer = 0
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Number of Client's currently in program: " & clients.Count)
        Console.WriteLine("Here's the client's currently in the program")

        Console.WriteLine("{0,-5} {1,-20} {2,-15} {3, -15}", "ID", "Name", "Date", "Time")
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("══════════════════════════════════════════════════════════════")
        Console.ForegroundColor = ConsoleColor.Yellow


        For i = 0 To clients.Count - 1
            If clients(i).Complete = complete Then


                Console.WriteLine("{0,-5} {1,-20} {2,-20} {3, -20}", i, clients(i).Name, clients(i).Dates.ToString("dd/MM/yy"), clients(i).time.ToString("hh:mm tt"))
            End If
        Next
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("══════════════════════════════════════════════════════════════")

        'Console.Write("Enter the index of the client: ")

        'index = Console.ReadLine

        ' Return index
    End Function

    Sub AddBooking()
        Dim NewClient As New Client
        Dim leave As Integer
        Dim selection As Char
        'Gather the input

        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Green
        Console.Write("Press -1 to cancel or 0 and enter to continue adding a client: ")
        Console.ForegroundColor = ConsoleColor.Yellow
        leave = Console.ReadLine
        If leave = -1 Then
            Console.Clear()
            Menu()

        Else
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write("Client's name: ")
            Console.ForegroundColor = ConsoleColor.Yellow
            NewClient.Name = Console.ReadLine
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write("Client's's address: ")
            Console.ForegroundColor = ConsoleColor.Yellow
            NewClient.Address = Console.ReadLine
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write("Client's's phone number: ")
            Console.ForegroundColor = ConsoleColor.Yellow
            NewClient.Phone = Console.ReadLine

            Console.ForegroundColor = ConsoleColor.Green

            Console.Write("Date of the booking (dd/mm/yy): ")
            Console.ForegroundColor = ConsoleColor.Yellow
            NewClient.Dates = Console.ReadLine
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write("Time of the booking (hh:mm am/pm): ")
            Console.ForegroundColor = ConsoleColor.Yellow
            NewClient.time = Console.ReadLine

            'Add to the list 
            'clients.Add(NewClient)

            Console.Clear()
            ' BookingDetailsYesOrNo()
            Console.WriteLine("Booking details are as follows:")


            Console.WriteLine("Name : " & NewClient.Name)
            Console.WriteLine("Address : " & NewClient.Address)
            Console.WriteLine("Phone number : " & NewClient.Phone)
            Console.WriteLine("Date of booking : " & NewClient.Dates)
            Console.WriteLine("Time of booking : " & NewClient.time)

            Console.WriteLine("Are these correct? Y/N")


            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper

            Select Case selection
                Case "Y"
                    clients.Add(NewClient)
                    Console.WriteLine("Booking added!")
                    ' Console.ReadLine
                Case "N"
                    clients.Remove(NewClient)
                    Console.Clear()
            End Select
            'Console.ReadLine()
        End If



       
    End Sub
    'Sub 




    'End Sub

    Sub ViewIncompleteBookings()

        If clients.Count = 0 Then
            Console.Clear()
            Console.WriteLine("No bookings available!")
            Console.WriteLine("Press any key to return to menu...")
            Console.ReadKey()
        Else

            Dim index As Integer = GetBookings(False)

            
        End If
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Press any key to return to menu: ")
        Console.ReadKey()
    End Sub
    Sub ViewCompleteBookings()

        
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Here's the client's currently completed in the program")

        Console.WriteLine("{0,-5} {1,-20} {2,-15} {3, -15}", "ID", "Name", "Date", "Time")
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("═════════════════════════════════════════════════════════════")
        Console.ForegroundColor = ConsoleColor.Yellow

        For i = 0 To clients.Count - 1
            If clients(i).Complete = True Then
                Console.WriteLine("{0,-5} {1,-20} {2,-20} {3, -20}", i, clients(i).Name, clients(i).Dates.ToString("dd/MM/yy"), clients(i).time.ToString("hh:mm tt"))
            End If
        Next
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("══════════════════════════════════════════════════════════════")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Press any key to return to menu...")
        Console.ReadKey()
    End Sub
    Sub CheckIncompleteBookingsForNext7Days()
        If clients.Count = 0 Then
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("You have no bookings")
            Console.Write("Press any key to exit...")
            Console.ReadKey()
        Else
            Console.Clear()
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("Here's the client's coming up in the next 7 days")

            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3, -15}", "ID", "Name", "Date", "Time")
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("═════════════════════════════════════════════════════════════")
            Console.ForegroundColor = ConsoleColor.Yellow

            For i = 0 To clients.Count - 1
                If clients(i).Complete = False And clients(i).Dates <= Now.AddDays(7) And clients(i).Dates >= Now Then
                    Console.WriteLine("{0,-5} {1,-20} {2,-20} {3, -20}", i, clients(i).Name, clients(i).Dates.ToString("dd/MM/yy"), clients(i).time.ToString("hh:mm tt"))
                End If
            Next
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("══════════════════════════════════════════════════════════════")
        End If

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Press any key to return to menu...")
        Console.ReadKey()
    End Sub
    Sub ViewIncompleteBookingsDetails()
        Dim index As Integer = GetBookings(False)
        Dim user As Integer
        'Console.WriteLine("Here are your incomplete bookings: ")

        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write("Press -1 to cancel or 0 and enter to continue: ")
        index = Console.ReadLine
        If index = -1 Then
            Menu()

        Else
            Console.Write("Enter the index of the client: ")

            user = Console.ReadLine


            Console.WriteLine("Name : " & clients(index).Name)

            Console.WriteLine("Address : " & clients(index).Address)

            Console.WriteLine("Phone number : " & clients(index).Phone)

            Console.WriteLine("Date of appointment : " & clients(index).Dates)

            Console.WriteLine("Time of appointment : " & clients(index).time)

            Console.WriteLine("Press any key to return to menu... ")

            Console.ReadKey()
        End If

       
    End Sub
    Sub EditIncompleteBookingsDetails()
        Console.Clear()
        Dim index As Integer = GetBookings(False)
        Console.ForegroundColor = ConsoleColor.Yellow
        If index >= 0 And index < clients.Count Then
            Dim selection As Char
            Console.WriteLine("Do you wish to edit a client? Y/N: ")
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper
            Select Case selection
                Case "Y"
                    Console.Write("Enter the index of the client you wish to edit: ")

                    index = Console.ReadLine

                    Console.Write("Clients name: ")
                    clients(index).Name = Console.ReadLine

                    Console.Write("Client's's address: ")
                    clients(index).Address = Console.ReadLine

                    Console.Write("Client's's phone number: ")
                    clients(index).Phone = Console.ReadLine

                    Console.Write("Date of the booking (dd/mm/yy): ")
                    clients(index).Dates = Console.ReadLine

                    Console.Write("Time of the booking (hh:mm am/pm): ")
                    clients(index).time = Console.ReadLine
                Case "N"
                    Console.WriteLine("Press any key to return to menu")
                    Console.ReadKey()
            End Select
            
        End If
        Console.Clear()
    End Sub
    Sub RemoveABooking()
        Console.Clear()
        Dim index As Integer = GetBookings(False)
        Console.ForegroundColor = ConsoleColor.Yellow

        Console.Write("Enter the index of the client you wish to remove: ")

        index = Console.ReadLine
        If index >= 0 And index < clients.Count Then
            Console.WriteLine("Do you wish to remove this client? Y/N: ")
            Dim selection As Char
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper

            Select Case selection
                Case "Y"
                    clients.RemoveAt(index)
                    Console.WriteLine("Booking Removed!")
                    Console.ReadKey()
                Case "N"

                    Console.Clear()
                    Console.WriteLine("Booking kept")
                    Console.WriteLine("Press any key to continue")
                    Console.ReadKey()
            End Select
        End If
    End Sub
    Sub CompleteBooking()
        Dim index As Integer = GetBookings(False)

        Console.ForegroundColor = ConsoleColor.Yellow
        
        Console.Write("Enter the index of the client: ")

        index = Console.ReadLine
        Dim newClient As New Client
        If index >= 0 And index < clients.Count Then

            Console.Write("Do you want to complete this booking y/n?:")

            Dim selection As Char
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper
            Select Case selection
                Case "Y"
                    Console.WriteLine("")
                    Console.Write("Booking Completed")
                    clients(index).Complete = True
                    Console.WriteLine("")
                    Console.Write("How many hours did it take to complete the job?: ")
                    company.TotalHours += Console.ReadLine

                    company.totalIncome = company.TotalHours * company.Rate
                Case "N"
                    Console.Clear()
            End Select
        End If
    End Sub
    Sub ViewBusinessCard()
        Console.Clear()

        Console.ForegroundColor = ConsoleColor.Green
        Console.SetCursorPosition(15, 9)
        Console.WriteLine("╔══════════════════════════════════════════════╗")
        Console.SetCursorPosition(15, 10)
        Console.WriteLine("║")
        Console.SetCursorPosition(15, 11)
        Console.WriteLine("║")
        Console.SetCursorPosition(15, 12)
        Console.WriteLine("║")
        Console.SetCursorPosition(15, 13)
        Console.WriteLine("║")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.SetCursorPosition(17, 10)
        Console.WriteLine("Company: " & company.business)
        Console.SetCursorPosition(17, 11)
        Console.WriteLine("Owner: " & company.name)
        Console.SetCursorPosition(17, 12)
        Console.WriteLine("Phone Number: " & company.number)
        Console.SetCursorPosition(17, 13)
        Console.WriteLine("Address: " & company.address)
        Console.SetCursorPosition(15, 14)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("╚══════════════════════════════════════════════╝")
        Console.SetCursorPosition(62, 10)
        Console.WriteLine("║")
        Console.SetCursorPosition(62, 11)
        Console.WriteLine("║")
        Console.SetCursorPosition(62, 12)
        Console.WriteLine("║")
        Console.SetCursorPosition(62, 13)
        Console.WriteLine("║")
        Console.ReadLine()
    End Sub
    

    Sub EditCompanyInfo()
        Console.Clear()





        Console.ForegroundColor = ConsoleColor.Yellow
        Dim correct As Char
        Dim choice As Char
        Dim selection As Char
        Console.WriteLine("Do you wish to edit your comany? Y/N: ")
        selection = Console.ReadKey(True).KeyChar.ToString.ToUpper
        If selection = "Y" Then
            Console.WriteLine("What Company information would you like to change: ")
            Console.WriteLine("(A)Company name: " & company.business)
            Console.WriteLine()
            Console.WriteLine("(B)Company Owner: " & company.name)
            Console.WriteLine()
            Console.WriteLine("(C)Company contact number: " & company.number)
            Console.WriteLine()
            Console.WriteLine("(D)Company address: " & company.address)
            Console.WriteLine()
            Console.WriteLine("(E)Company hourly rate :$" & company.Rate)
            Console.WriteLine()
            Console.WriteLine("(X) Return to menu")

            choice = Console.ReadKey(True).KeyChar.ToString.ToUpper
            Select Case choice

                Case "A"
                    Console.Clear()
                    Console.Write("New company name: ")
                    company.business = Console.ReadLine
                    Console.WriteLine("Your new company name is: " & company.business)
                    ' Console.WriteLine("Y/N")
                    ' correct = Console.ReadKey(True).KeyChar.ToString.ToUpper
                    ' If correct = "Y" Then
                    'Console.WriteLine("You have changed your company's name")
                    ' Console.WriteLine("Press any key to continue...")
                    ' saveCompany()
                    ' Console.ReadKey()

                    ' ElseIf correct = "N" Then
                    ' Console.WriteLine("Press any key to return to menu...")
                    ' Console.ReadKey()
                    'End If


                Case "B"
                    Console.Clear()
                    Console.Write("New company owner: ")
                    company.name = Console.ReadLine
                    Console.WriteLine("Press any key to continue...")
                    Console.ReadKey()
                Case "C"
                    Console.Clear()
                    Console.Write("New company contact number: ")
                    company.number = Console.ReadLine
                    Console.WriteLine("Press any key to continue...")
                    Console.ReadKey()
                Case "D"
                    Console.Clear()
                    Console.Write("New company address: ")
                    company.address = Console.ReadLine
                    Console.WriteLine("Press any key to continue...")
                    Console.ReadKey()
                Case "E"
                    Console.Clear()
                    Console.Write("New company hourly rate:$")
                    company.Rate = Console.ReadLine
                    Console.WriteLine("Press any key to continue...")
                    Console.ReadKey()
                Case "X"
                    Menu()
            End Select
            Console.Clear()


        ElseIf selection = "N" Then


            Console.WriteLine("Press any key to return to menu")
            Console.ReadKey()
            Console.Clear()


        End If
    End Sub
    Sub Menu()

        Dim selection As Char

        Do
            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.Green
            Console.Clear()
            CompanyInfo()
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("Todays clients")

            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3, -15}", "ID", "Name", "Date", "Time")
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("═════════════════════════════════════════════════════════════")
            Console.ForegroundColor = ConsoleColor.Yellow

            For i = 0 To clients.Count - 1
                If clients(i).Complete = False And clients(i).Dates <= Now.AddDays(1) And clients(i).Dates >= Now.AddDays(-1) Then
                    Console.WriteLine("{0,-5} {1,-20} {2,-20} {3, -20}", i, clients(i).Name, clients(i).Dates.ToString("dd/MM/yy"), clients(i).time.ToString("hh:mm tt"))
                Else

                End If
            Next
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("═════════════════════════════════════════════════════════════")
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("Select from one of the following menu options:")
            Console.WriteLine()
            Console.WriteLine("(A) Add a booking")
            Console.WriteLine("(B) View all incomplete bookings")
            Console.WriteLine("(C) View all complete bookings")
            Console.WriteLine("(D) Check incomplete bookings for next 7 days")
            Console.WriteLine()
            Console.WriteLine("(E) View incomplete booking's details")
            Console.WriteLine("(F) Edit incomplete bookings details")
            Console.WriteLine()
            Console.WriteLine("(G) Remove a booking")
            Console.WriteLine("(H) Complete a booking")
            Console.WriteLine()
            Console.WriteLine("(I) View business card")
            Console.WriteLine("(J) Edit company information")
            Console.WriteLine()
            Console.WriteLine("(X) Save and Exit")
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("═════════════════════════════════════════════════════════════")

            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper
            Select Case selection
                Case "A"
                    AddBooking()
                Case "B"
                    ViewIncompleteBookings()
                Case "C"
                    ViewCompleteBookings()
                Case "D"
                    CheckIncompleteBookingsForNext7Days()
                Case "E"
                    ViewIncompleteBookingsDetails()
                Case "F"
                    EditIncompleteBookingsDetails()
                Case "G"
                    RemoveABooking()
                Case "H"
                    CompleteBooking()
                Case "I"
                    ViewBusinessCard()
                Case "J"
                    EditCompanyInfo()

            End Select
            Console.Clear()
        Loop Until selection = "X"
        saveCompany()

        Console.Clear()

        Dim savingWord As String = "Saving"
        Dim saving As Integer
        Dim finished As Boolean = False
        Dim rand As New Random
        Dim delaycount As Integer = rand.Next(0, 30)
        Dim count As Integer = 0


        While Not finished
            'By Jarod "The Little Master" Inzitari
            'slow down
            Threading.Thread.Sleep(20)

            Console.SetCursorPosition(saving + 34, 10)
            Console.BackgroundColor = ConsoleColor.Red
            Console.ForegroundColor = ConsoleColor.Yellow

            'Put down 10 rand numbers
            For i = saving To 5
                Console.Write(savingWord(i))

            Next

            count += 1

            'Check if we hit the threshold

            If count = delaycount Then
                Console.BackgroundColor = ConsoleColor.DarkGreen
                Console.SetCursorPosition(saving + 34, 10)
                Console.Write(savingWord(saving))

                saving += 1
                count = 0
                delaycount = rand.Next(0, 30)


            End If

            If saving = 6 Then
                finished = True
                Console.BackgroundColor = ConsoleColor.Black
            End If



        End While


        Console.SetCursorPosition(saving + 28, 10)
        Console.BackgroundColor = ConsoleColor.DarkGreen

        Console.WriteLine("Goodbye")
        Threading.Thread.Sleep(1140)

        'By Jarod "The Little Master" Inzitari



    End Sub



    Sub start()

        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.Green
        Console.Clear()
        Console.SetCursorPosition(17, 8)
        Console.WriteLine("╔════════════════════════════════════════╗")
        Console.SetCursorPosition(17, 9)
        Console.WriteLine("║")
        Console.SetCursorPosition(17, 10)
        Console.WriteLine("║")
        Console.SetCursorPosition(17, 11)
        Console.WriteLine("║")
        Console.SetCursorPosition(17, 12)
        Console.WriteLine("║")
        Console.SetCursorPosition(17, 13)
        Console.WriteLine("║")
        Console.SetCursorPosition(58, 9)
        Console.WriteLine("║")
        Console.SetCursorPosition(58, 10)
        Console.WriteLine("║")
        Console.SetCursorPosition(58, 11)
        Console.WriteLine("║")
        Console.SetCursorPosition(58, 12)
        Console.WriteLine("║")
        Console.SetCursorPosition(58, 13)
        Console.WriteLine("║")
        Console.SetCursorPosition(23, 10)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("Welcome to Fun With Lawns v0.1")
        Console.SetCursorPosition(19, 11)
        Console.WriteLine("Your all in one lawn management system")
        Console.WriteLine("")
        Console.SetCursorPosition(24, 12)
        Console.WriteLine("Press any key to continue...")
        Console.ForegroundColor = ConsoleColor.Green
        Console.SetCursorPosition(17, 14)
        Console.WriteLine("╚════════════════════════════════════════╝")

        Console.ReadKey()
        Console.Clear()
        If IO.File.Exists("CompanyData.txt") Then
            Console.Clear()

        Else


            Console.WriteLine("No company info has been found. We'll setup a profile before we begin")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
            Console.Clear()
            Console.WriteLine("Here you enter the details for your new company profile")
            Console.WriteLine()
            Console.Write("Company Name: ")
            company.business = Console.ReadLine
            Console.Write("Company owner's name: ")
            company.name = Console.ReadLine
            Console.Write("Company Contact number: ")
            company.number = Console.ReadLine
            Console.Write("Company Address: ")
            company.address = Console.ReadLine
            Console.Write("Company Hourly Rate: $")
            company.Rate = Console.ReadLine
            Console.WriteLine("Setup is complete")
            Console.WriteLine()
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
        End If
        Menu()
    End Sub
    Sub Main()

        loadCompany()
        start()



    End Sub

End Module
