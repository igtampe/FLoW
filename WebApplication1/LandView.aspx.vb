Imports System.IO

Public Class LandView
    Inherits System.Web.UI.Page


    Public Structure LandStructure
        Public ID As String
        Public Status As String
        Public Height As Integer
        Public Width As Integer
        Public Area As Integer
        Public Price As String
        Public Owner As String
        Public Comment As String
        Public PricePerBlock As String
    End Structure

    Public Structure AllPlots
        Public Industrial() As LandStructure
        Public UMSMain() As LandStructure
        Public Suburbia() As LandStructure
        Public Urbia() As LandStructure
        Public Paradisus() As LandStructure
        Public Domum() As LandStructure
        Public Laetres() As LandStructure

    End Structure

    Public I As Integer = 0
    Public U As Integer = 0
    Public S As Integer = 0
    Public R As Integer = 0
    Public P As Integer = 0
    Public D As Integer = 0
    Public L As Integer = 0
    Public status As String

    Public Plot As AllPlots

    Sub HeyItsTimeToLoad() Handles Me.Load

        DownloadToTemp("LandDatabase.csv")

        Dim currentline() As String
        I = 0
        U = 0
        S = 0
        R = 0
        P = 0
        D = 0
        L = 0

        FileOpen(1, My.Computer.FileSystem.SpecialDirectories.Temp & "\" & "LandDatabase.csv", OpenMode.Input)
        While Not EOF(1)
            currentline = LineInput(1).Split(",")
            If currentline(0).StartsWith("I") Then
                ReDim Preserve Plot.Industrial(I)

                Plot.Industrial(I).ID = currentline(0)
                Plot.Industrial(I).Owner = currentline(1)
                Plot.Industrial(I).Comment = currentline(2)

                Select Case currentline(3)
                    Case 0
                        Plot.Industrial(I).Status = "Sold or Not For Sale"
                    Case 1
                        Plot.Industrial(I).Status = "For Sale"
                    Case 2
                        Plot.Industrial(I).Status = "For Sale by a Third Party"
                End Select

                Plot.Industrial(I).Height = currentline(4)
                Plot.Industrial(I).Width = currentline(5)
                Plot.Industrial(I).PricePerBlock = currentline(6)
                Plot.Industrial(I).Price = currentline(7)

                Plot.Industrial(I).Area = Plot.Industrial(I).Width * Plot.Industrial(I).Height
                I = I + 1

            ElseIf currentline(0).StartsWith("U") Then
                ReDim Preserve Plot.UMSMain(U)


                Plot.UMSMain(U).ID = currentline(0)
                Plot.UMSMain(U).Owner = currentline(1)
                Plot.UMSMain(U).Comment = currentline(2)

                Select Case currentline(3)
                    Case 0
                        Plot.UMSMain(U).Status = "Sold or Not For Sale"
                    Case 1
                        Plot.UMSMain(U).Status = "For Sale"
                    Case 2
                        Plot.UMSMain(U).Status = "For Sale by a Third Party"
                End Select

                Plot.UMSMain(U).Height = currentline(4)
                Plot.UMSMain(U).Width = currentline(5)
                Plot.UMSMain(U).PricePerBlock = currentline(6)
                Plot.UMSMain(U).Price = currentline(7)

                Plot.UMSMain(U).Area = Plot.UMSMain(U).Width * Plot.UMSMain(U).Height
                U = U + 1

            ElseIf currentline(0).StartsWith("S") Then
                ReDim Preserve Plot.Suburbia(S)


                Plot.Suburbia(S).ID = currentline(0)
                Plot.Suburbia(S).Owner = currentline(1)
                Plot.Suburbia(S).Comment = currentline(2)

                Select Case currentline(3)
                    Case 0
                        Plot.Suburbia(S).Status = "Sold or Not For Sale"
                    Case 1
                        Plot.Suburbia(S).Status = "For Sale"
                    Case 2
                        Plot.Suburbia(S).Status = "For Sale by a Third Party"
                End Select

                Plot.Suburbia(S).Height = currentline(4)
                Plot.Suburbia(S).Width = currentline(5)
                Plot.Suburbia(S).PricePerBlock = currentline(6)
                Plot.Suburbia(S).Price = currentline(7)

                Plot.Suburbia(S).Area = Plot.Suburbia(S).Width * Plot.Suburbia(S).Height
                S = S + 1

            ElseIf currentline(0).StartsWith("R") Then
                ReDim Preserve Plot.Urbia(R)


                Plot.Urbia(R).ID = currentline(0)
                Plot.Urbia(R).Owner = currentline(1)
                Plot.Urbia(R).Comment = currentline(2)

                Select Case currentline(3)
                    Case 0
                        Plot.Urbia(R).Status = "Sold or Not For Sale"
                    Case 1
                        Plot.Urbia(R).Status = "For Sale"
                    Case 2
                        Plot.Urbia(R).Status = "For Sale by a Third Party"
                End Select

                Plot.Urbia(R).Height = currentline(4)
                Plot.Urbia(R).Width = currentline(5)
                Plot.Urbia(R).PricePerBlock = currentline(6)
                Plot.Urbia(R).Price = currentline(7)

                Plot.Urbia(R).Area = Plot.Urbia(R).Width * Plot.Urbia(R).Height
                R = R + 1

            ElseIf currentline(0).StartsWith("P") Then
                ReDim Preserve Plot.Paradisus(P)


                Plot.Paradisus(P).ID = currentline(0)
                Plot.Paradisus(P).Owner = currentline(1)
                Plot.Paradisus(P).Comment = currentline(2)

                Select Case currentline(3)
                    Case 0
                        Plot.Paradisus(P).Status = "Sold or Not For Sale"
                    Case 1
                        Plot.Paradisus(P).Status = "For Sale"
                    Case 2
                        Plot.Paradisus(P).Status = "For Sale by a Third Party"
                End Select

                Plot.Paradisus(P).Height = currentline(4)
                Plot.Paradisus(P).Width = currentline(5)
                Plot.Paradisus(P).PricePerBlock = currentline(6)
                Plot.Paradisus(P).Price = currentline(7)

                Plot.Paradisus(P).Area = Plot.Paradisus(P).Width * Plot.Paradisus(P).Height
                P = P + 1

            ElseIf currentline(0).StartsWith("D") Then
                ReDim Preserve Plot.Domum(D)


                Plot.Domum(D).ID = currentline(0)
                Plot.Domum(D).Owner = currentline(1)
                Plot.Domum(D).Comment = currentline(2)

                Select Case currentline(3)
                    Case 0
                        Plot.Domum(D).Status = "Sold or Not For Sale"
                    Case 1
                        Plot.Domum(D).Status = "For Sale"
                    Case 2
                        Plot.Domum(D).Status = "For Sale by a Third Party"
                End Select

                Plot.Domum(D).Height = currentline(4)
                Plot.Domum(D).Width = currentline(5)
                Plot.Domum(D).PricePerBlock = currentline(6)
                Plot.Domum(D).Price = currentline(7)

                Plot.Domum(D).Area = Plot.Domum(D).Width * Plot.Domum(D).Height
                D = D + 1

            ElseIf currentline(0).StartsWith("L") Then
                ReDim Preserve Plot.Laetres(L)


                Plot.Laetres(L).ID = currentline(0)
                Plot.Laetres(L).Owner = currentline(1)
                Plot.Laetres(L).Comment = currentline(2)

                Select Case currentline(3)
                    Case 0
                        Plot.Laetres(L).Status = "Sold or Not For Sale"
                    Case 1
                        Plot.Laetres(L).Status = "For Sale"
                    Case 2
                        Plot.Laetres(L).Status = "For Sale by a Third Party"
                End Select

                Plot.Laetres(L).Height = currentline(4)
                Plot.Laetres(L).Width = currentline(5)
                Plot.Laetres(L).PricePerBlock = currentline(6)
                Plot.Laetres(L).Price = currentline(7)

                Plot.Laetres(L).Area = Plot.Laetres(L).Width * Plot.Laetres(L).Height
                L = L + 1
            End If

        End While

        FileClose(1)

    End Sub

    Protected Sub Page_Load() Handles DropDownList1.SelectedIndexChanged
        Dim N As Integer

        DropDownList2.Items.Clear()
        DropDownList2.Text = ""
        DropDownList2.Enabled = True

        Select Case DropDownList1.SelectedIndex
            Case 0 'Select an Item
                PlotLBL.Text = ""
                StatusLBL.Text = ""
                OwnerLBL.Text = ""
                SizeLBL.Text = ""
                AreaLBL.Text = ""
                CommentLBL.Text = ""
                PriceLBL.Text = ""
                PPBlockLBL.Text = ""
                DropDownList2.Enabled = False

            Case 1 'industrial
                For N = 0 To I - 1
                    DropDownList2.Items.Add(Plot.Industrial(N).ID)
                Next
            Case 2 'ums main
                For N = 0 To U - 1
                    DropDownList2.Items.Add(Plot.UMSMain(N).ID)
                Next
            Case 3 'Suburbia
                For N = 0 To S - 1
                    DropDownList2.Items.Add(Plot.Suburbia(N).ID)
                Next
            Case 4 'urbia
                For N = 0 To R - 1
                    DropDownList2.Items.Add(Plot.Urbia(N).ID)
                Next
            Case 5 'paradisus
                For N = 0 To P - 1
                    DropDownList2.Items.Add(Plot.Paradisus(N).ID)
                Next
            Case 6 'domum
                For N = 0 To D - 1
                    DropDownList2.Items.Add(Plot.Domum(N).ID)
                Next
            Case 7 'laetres
                For N = 0 To L - 1
                    DropDownList2.Items.Add(Plot.Laetres(N).ID)
                Next
        End Select
        Image1.ImageUrl = "http://igtnet-w.ddns.net:100/plotview/" & DropDownList1.SelectedItem.Value & ".png"
        DropDownList2_SelectedIndexChanged()
        ShowPanel.Visible = True
        DropDownList2.Enabled = True


    End Sub


    Sub DownloadToTemp(filetodownload As String)
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & filetodownload) Then File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "\" & filetodownload)
        My.Computer.Network.DownloadFile("http://igtnet-w.ddns.net:100/PlotView/" & filetodownload, My.Computer.FileSystem.SpecialDirectories.Temp & "\" & filetodownload)
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged() Handles DropDownList2.SelectedIndexChanged


        Dim N As Integer = DropDownList2.SelectedIndex

        Select Case DropDownList1.SelectedIndex

            Case 0
                PlotLBL.Text = ""
                StatusLBL.Text = ""
                OwnerLBL.Text = ""
                SizeLBL.Text = ""
                AreaLBL.Text = ""
                CommentLBL.Text = ""
                PriceLBL.Text = ""
                PPBlockLBL.Text = ""


            Case 1 'industrial
                PlotLBL.Text = Plot.Industrial(N).ID
                StatusLBL.Text = Plot.Industrial(N).Status
                OwnerLBL.Text = Plot.Industrial(N).Owner
                SizeLBL.Text = Plot.Industrial(N).Width & " x " & Plot.Industrial(N).Height
                AreaLBL.Text = Plot.Industrial(N).Area & "m^2"
                CommentLBL.Text = Plot.Industrial(N).Comment

                Select Case StatusLBL.Text
                    Case "For Sale"

                        PriceLBL.Text = CInt(Plot.Industrial(N).Price).ToString("N0") & "p"
                        PPBlockLBL.Text = CInt(Plot.Industrial(N).PricePerBlock).ToString("N0") & "p"

                    Case Else

                        PriceLBL.Text = "Ask 3rd Party"
                        PPBlockLBL.Text = "None Set"


                End Select


            Case 2 'ums main
                PlotLBL.Text = Plot.UMSMain(N).ID
                StatusLBL.Text = Plot.UMSMain(N).Status
                OwnerLBL.Text = Plot.UMSMain(N).Owner
                SizeLBL.Text = Plot.UMSMain(N).Width & " x " & Plot.UMSMain(N).Height
                AreaLBL.Text = Plot.UMSMain(N).Area & "m^2"
                CommentLBL.Text = Plot.UMSMain(N).Comment

                Select Case StatusLBL.Text
                    Case "For Sale"

                        PriceLBL.Text = CInt(Plot.UMSMain(N).Price).ToString("N0") & "p"
                        PPBlockLBL.Text = CInt(Plot.UMSMain(N).PricePerBlock).ToString("N0") & "p"

                    Case Else

                        PriceLBL.Text = "Ask 3rd Party"
                        PPBlockLBL.Text = "None Set"


                End Select


            Case 3 'Suburbia
                PlotLBL.Text = Plot.Suburbia(N).ID
                StatusLBL.Text = Plot.Suburbia(N).Status
                OwnerLBL.Text = Plot.Suburbia(N).Owner
                SizeLBL.Text = Plot.Suburbia(N).Width & " x " & Plot.Suburbia(N).Height
                AreaLBL.Text = Plot.Suburbia(N).Area & "m^2"
                CommentLBL.Text = Plot.Suburbia(N).Comment

                Select Case StatusLBL.Text
                    Case "For Sale"

                        PriceLBL.Text = CInt(Plot.Suburbia(N).Price).ToString("N0") & "p"
                        PPBlockLBL.Text = CInt(Plot.Suburbia(N).PricePerBlock).ToString("N0") & "p"

                    Case Else

                        PriceLBL.Text = "Ask 3rd Party"
                        PPBlockLBL.Text = "None Set"


                End Select


            Case 4 'urbia
                PlotLBL.Text = Plot.Urbia(N).ID
                StatusLBL.Text = Plot.Urbia(N).Status
                OwnerLBL.Text = Plot.Urbia(N).Owner
                SizeLBL.Text = Plot.Urbia(N).Width & " x " & Plot.Urbia(N).Height
                AreaLBL.Text = Plot.Urbia(N).Area & "m^2"
                CommentLBL.Text = Plot.Urbia(N).Comment

                Select Case StatusLBL.Text
                    Case "For Sale"

                        PriceLBL.Text = CInt(Plot.Urbia(N).Price).ToString("N0") & "p"
                        PPBlockLBL.Text = CInt(Plot.Urbia(N).PricePerBlock).ToString("N0") & "p"

                    Case Else

                        PriceLBL.Text = "Ask 3rd Party"
                        PPBlockLBL.Text = "None Set"


                End Select


            Case 5 'paradisus
                PlotLBL.Text = Plot.Paradisus(N).ID
                StatusLBL.Text = Plot.Paradisus(N).Status
                OwnerLBL.Text = Plot.Paradisus(N).Owner
                SizeLBL.Text = Plot.Paradisus(N).Width & " x " & Plot.Paradisus(N).Height
                AreaLBL.Text = Plot.Paradisus(N).Area & "m^2"
                CommentLBL.Text = Plot.Paradisus(N).Comment

                Select Case StatusLBL.Text
                    Case "For Sale"

                        PriceLBL.Text = CInt(Plot.Paradisus(N).Price).ToString("N0") & "p"
                        PPBlockLBL.Text = CInt(Plot.Paradisus(N).PricePerBlock).ToString("N0") & "p"

                    Case Else

                        PriceLBL.Text = "Ask 3rd Party"
                        PPBlockLBL.Text = "None Set"


                End Select


            Case 6 'domum
                PlotLBL.Text = Plot.Domum(N).ID
                StatusLBL.Text = Plot.Domum(N).Status
                OwnerLBL.Text = Plot.Domum(N).Owner
                SizeLBL.Text = Plot.Domum(N).Width & " x " & Plot.Domum(N).Height
                AreaLBL.Text = Plot.Domum(N).Area & "m^2"
                CommentLBL.Text = Plot.Domum(N).Comment

                Select Case StatusLBL.Text
                    Case "For Sale"

                        PriceLBL.Text = CInt(Plot.Domum(N).Price).ToString("N0") & "p"
                        PPBlockLBL.Text = CInt(Plot.Domum(N).PricePerBlock).ToString("N0") & "p"

                    Case Else

                        PriceLBL.Text = "Ask 3rd Party"
                        PPBlockLBL.Text = "None Set"


                End Select


            Case 7 'laetres
                PlotLBL.Text = Plot.Laetres(N).ID
                StatusLBL.Text = Plot.Laetres(N).Status
                OwnerLBL.Text = Plot.Laetres(N).Owner
                SizeLBL.Text = Plot.Laetres(N).Width & " x " & Plot.Laetres(N).Height
                AreaLBL.Text = Plot.Laetres(N).Area & "m^2"
                CommentLBL.Text = Plot.Laetres(N).Comment

                Select Case StatusLBL.Text
                    Case "For Sale"

                        PriceLBL.Text = CInt(Plot.Laetres(N).Price).ToString("N0") & "p"
                        PPBlockLBL.Text = CInt(Plot.Laetres(N).PricePerBlock).ToString("N0") & "p"

                    Case Else

                        PriceLBL.Text = "Ask 3rd Party"
                        PPBlockLBL.Text = "None Set"


                End Select


        End Select

    End Sub


End Class