Module Module1

    Class Client
        Public Name As String
        Public Address As String
        Public Phone As Integer
        Public Dates As Date
        Public time As Date
    End Class
    Dim completedClients As New List(Of Client)
    Dim clients As New List(Of Client)
    Function GetBookings()
        Console.Clear()
        Dim index As Integer = 0
        Console.WriteLine("Number of Client's currently in program: " & clients.Count)
        Console.WriteLine("Here's the client's currently in the program")

        Console.WriteLine("{0,-5} {1,-20} {2,-15} {3, -15}", "ID", "Name", "Date", "Time")
        Console.WriteLine("======================================================")


        For i = 0 To clients.Count - 1

            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3, -20}", i, clients(i).Name, clients(i).Dates.ToString("dd/MM/yy"), clients(i).time.ToString("hh:mm tt"))

        Next

        Console.Write("Enter the index of the client: ")

        index = Console.ReadLine

        Return index
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

    End Sub
    Sub RemoveABooking()

    End Sub
    Sub CompleteBooking()
        Dim index As Integer = GetBookings()
        Dim newClient As New Client
        If index >= 0 And index < clients.Count Then

            Console.Write("Do you want to complete this booking y/n?:")
            Dim selection As Char
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper
            Select Case selection
                Case "Y"

                    Console.WriteLine("Booking Completed")
                    Console.ReadLine()
                Case "N"
                    Console.Clear()
            End Select
        End If
    End Sub
    Sub ViewBusinessCard()

    End Sub
    Sub Menu()
        Dim selection As Char

        Do
            Console.Clear()


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
        Menu()
    End Sub
    Sub Main()
        start()
    End Sub

End Module
