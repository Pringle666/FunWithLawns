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
    Dim completedClients As New List(Of Client)
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

        Console.WriteLine("Welcome " & company.name)
        Console.WriteLine("=====================================================================")
        Console.WriteLine("Total completed hours: " & company.TotalHours)
        Console.WriteLine("Total completed hours: " & company.totalIncome)
        Console.WriteLine("=====================================================================")

    End Sub
    Function GetBookings()
        Console.Clear()

        Console.WriteLine("Number of Client's currently in program: " & clients.Count)
        Console.WriteLine("Here's the client's currently in the program")

        Console.WriteLine("{0,-5} {1,-20} {2,-15} {3, -15}", "ID", "Name", "Date", "Time")
        Console.WriteLine("=============================================================")


        For i = 0 To clients.Count - 1

            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3, -20}", i, clients(i).Name, clients(i).Dates.ToString("dd/MM/yy"), clients(i).time.ToString("hh:mm tt"))

        Next

        'Console.Write("Enter the index of the client: ")

        'index = Console.ReadLine

        ' Return index
    End Function

    Sub AddBooking()
        Dim NewClient As New Client

        'Gather the input

        Console.Clear()
        Console.WriteLine("I'm going to add a student!")

        Console.Write("Client's name: ")
        NewClient.Name = Console.ReadLine

        Console.Write("Client's's address: ")
        NewClient.Address = Console.ReadLine

        Console.Write("Client's's phone number: ")
        NewClient.Phone = Console.ReadLine

        Console.Write("Date of the booking (dd/mm/yy): ")
        NewClient.Dates = Console.ReadLine

        Console.Write("Time of the booking (hh:mm am/pm): ")
        NewClient.time = Console.ReadLine

        'Add to the list 
        'clients.Add(NewClient)

        Console.Clear()
        ' BookingDetailsYesOrNo()
        Console.WriteLine("Booking details are as follows:")


        Console.WriteLine("Name :" & NewClient.Name)
        Console.WriteLine("Address :" & NewClient.Address)
        Console.WriteLine("Phone number :" & NewClient.Phone)
        Console.WriteLine("Date of booking :" & NewClient.Dates)
        Console.WriteLine("Time of booking :" & NewClient.time)

        Console.WriteLine("Are these correct? Y/N")

        Dim selection As Char
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
    End Sub
    'Sub 




    'End Sub

    Sub ViewIncompleteBookings()

        If clients.Count = 0 Then
            Console.Clear()
            Console.WriteLine("No bookings available!")

        Else

            Dim index As Integer = GetBookings()

            
        End If

        Console.ReadLine()
    End Sub
    Sub ViewCompleteBookings()

    End Sub
    Sub CheckIncompleteBookingsForNext7Days()

    End Sub
    Sub ViewIncompleteBookingsDetails()
        Dim index As Integer = GetBookings()
        Console.WriteLine("Here are your incomplete bookings: ")

        Console.WriteLine("Name : " & clients(index).Name)

        Console.WriteLine("Address : " & clients(index).Address)

        Console.WriteLine("Phone number : " & clients(index).Phone)

        Console.WriteLine("Date of appointment : " & clients(index).Dates)

        Console.WriteLine("Time of appointment : " & clients(index).time)

        Console.ReadLine()
    End Sub
    Sub EditIncompleteBookingsDetails()
        Console.Clear()
        Dim index As Integer = GetBookings()
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
        Dim index As Integer = GetBookings()


        Console.Write("Enter the index of the client you wish to remove: ")

        index = Console.ReadLine
        If index >= 0 And index < clients.Count Then
            Console.Write("Do you wish to remove this client? Y/N: ")
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
        Dim index As Integer = GetBookings()
        Dim user As Integer
        Console.Write("Enter the index of the client: ")

        user = Console.ReadLine
        Dim newClient As New Client
        If index >= 0 And index < clients.Count Then

            Console.Write("Do you want to complete this booking y/n?:")
            Dim selection As Char
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper
            Select Case selection
                Case "Y"

                    Console.WriteLine("Booking Completed")

                Case "N"
                    Console.Clear()
            End Select
        End If
    End Sub
    Sub ViewBusinessCard()
        Console.Clear()

        Console.WriteLine("Company: " & company.business)
        Console.WriteLine("Owner: " & company.name)
        Console.WriteLine("Phone Number: " & company.number)
        Console.WriteLine("Address: " & company.address)
        Console.ReadLine()
    End Sub
    Sub Menu()

        Dim selection As Char

        Do
            Console.Clear()
            CompanyInfo()

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
            Console.WriteLine()
            Console.WriteLine("(X) Exit")


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


            End Select
            Console.Clear()
        Loop Until selection = "X"
        saveCompany()
    End Sub



    Sub start()
        Console.SetCursorPosition(23, 0)
        Console.WriteLine("Welcome to Fun With Lawns v0.1")
        Console.SetCursorPosition(19, 1)
        Console.WriteLine("Your all in one lawn management system")
        Console.WriteLine("")
        Console.SetCursorPosition(23.5, 2)
        Console.WriteLine("Press any key to continue...")

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
