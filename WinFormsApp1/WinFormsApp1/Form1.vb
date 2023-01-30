Imports System.Reflection.Emit

Public Class Form1
    Dim voornaam As String
    Dim achternaam As String
    Dim gender As String
    Dim rekeningnummer As String
    Dim zichtrekening As Double
    Dim spaarrekening As Double
    Dim transacties() As String = {""}
    Dim i As Integer = 0
    Dim encryptie As Boolean = True
    Dim rente2024 As Double
    Dim rente2025 As Double
    Dim rente2026 As Double
    Dim aantal

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        voornaam = InputBox("Geef je voornaam in").ToUpper
        achternaam = InputBox("Geef je achternaam in").ToUpper
        gender = InputBox("Geef je gender in M/V/A").ToUpper
        rekeningnummer = InputBox("Geef je rekeningnummer in xx xxxx xxxx xxxx")
        Label1.Text = "Voornaam: " & voornaam
        Label2.Text = "Achternaam: " & achternaam
        Label3.Text = "Gender: " & gender
        Label4.Text = "Rekeningnummer: BE" & rekeningnummer
        Label5.Text = zichtrekening
        Label6.Text = spaarrekening
        Label7.Text = "Euro"
        Label8.Text = "Transacties"
        Label9.Text = "Huidige rentevoet 1,35%"


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If zichtrekening >= 250 Then
            MsgBox("Zichtrekening kan maar maximum tot 250 gaan")
            Label5.Text = zichtrekening
        Else
            Dim Geldstorten = InputBox("Hoeveel geld wil je storen?")
            If Geldstorten > 250 Then
                MsgBox("Dit bedrag is te hoog")
                Geldstorten = InputBox("Hoeveel geld wil je storen?")
                zichtrekening += Geldstorten
                For i As Integer = 0 To transacties.Length - 1
                    transacties(i) += Geldstorten

                    Array.Resize(transacties, transacties.Length + 1)
                    aantal = String.Join(" ", transacties)
                Next
            Else
                zichtrekening += Geldstorten
                For i As Integer = 0 To transacties.Length - 1
                    transacties(i) += Geldstorten

                    Array.Resize(transacties, transacties.Length + 1)
                    aantal = String.Join(" ", transacties)
                Next

            End If
            Label5.Text = zichtrekening
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim overzetten = InputBox("Hoeveel geld wil je overzetten?")
        If zichtrekening > overzetten Then
            zichtrekening -= overzetten
            spaarrekening += overzetten
            Label5.Text = zichtrekening
            Label6.Text = spaarrekening
        Else
            MsgBox("Je hebt niet genoeg geld op je zichtrekening")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim overzetten = InputBox("Hoeveel geld wil je overzetten?")
        If spaarrekening > overzetten Then
            zichtrekening += overzetten
            spaarrekening -= overzetten
            Label5.Text = zichtrekening
            Label6.Text = spaarrekening
        Else
            MsgBox("Je hebt niet genoeg geld op je zichtrekening")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If Label7.Text = "Euro" Then
            zichtrekening = zichtrekening * 1.0887
            spaarrekening = spaarrekening * 1.0887
            Label5.Text = Math.Round(zichtrekening)
            Label6.Text = Math.Round(spaarrekening)
            Label7.Text = "Dollar"
        ElseIf Label7.Text = "Pond" Then
            zichtrekening = zichtrekening * 1.0881
            spaarrekening = spaarrekening * 1.0881
            Label5.Text = Math.Round(zichtrekening)
            Label6.Text = Math.Round(spaarrekening)
            Label7.Text = "Dollar"
        End If



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Label7.Text = "Euro" Then
            zichtrekening = zichtrekening * 0.8798
            spaarrekening = spaarrekening * 0.8798
            Label5.Text = Math.Round(zichtrekening)
            Label6.Text = Math.Round(spaarrekening)
            Label7.Text = "Pond"
        ElseIf Label7.Text = "Dollar" Then
            zichtrekening = zichtrekening * 0.919
            spaarrekening = spaarrekening * 0.919
            Label5.Text = Math.Round(zichtrekening)
            Label6.Text = Math.Round(spaarrekening)
            Label7.Text = "Pond"
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Label7.Text = "Dollar" Then
            zichtrekening = zichtrekening * 0.9185
            spaarrekening = spaarrekening * 0.9185
            Label5.Text = Math.Round(zichtrekening)
            Label6.Text = Math.Round(spaarrekening)
            Label7.Text = "Euro"
        ElseIf Label7.Text = "Pond" Then
            zichtrekening = zichtrekening * 1.1371
            spaarrekening = spaarrekening * 1.1371
            Label5.Text = Math.Round(zichtrekening)
            Label6.Text = Math.Round(spaarrekening)
            Label7.Text = "Euro"
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If encryptie = True Then
            Label4.Text = ("Rekeningnummer " & "BEXX XXXX XXXX XXXX")
            encryptie = False
        Else

            Label4.Text = ("Rekeningnummer: " & rekeningnummer)
            encryptie = True
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        rente2024 = spaarrekening * 1.35
        Label9.Text = ("Interest voor 2024 " + Math.Round(rente2024, 2))
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        rente2025 = (spaarrekening * 1.35) * 2
        Label9.Text = ("Interest voor 2025 " + Math.Round(rente2025, 2))
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        rente2026 = (spaarrekening * 1.35) * 3
        Label9.Text = ("Interest voor 2026 " + Math.Round(rente2026, 2))
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Dim aantal = String.Join(" ", transacties)
        Label8.Text = (" " & aantal)

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim vraagTrans = InputBox("Geef een transactie die je wilt bekijken")
        MsgBox("De transactie is " + transacties(vraagTrans))
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub
End Class
