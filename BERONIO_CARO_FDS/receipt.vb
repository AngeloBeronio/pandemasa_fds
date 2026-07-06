Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Module receipt

    Public OrderId As Integer
    Public CashAmount As Decimal
    Public ChangeAmount As Decimal
    Public FeeAmount As Decimal
    Public PaymentMethod As String = "Cash"
    Public RefNumber As String = ""

    Public Sub GenerateReceipt(orderId As Integer, subtotal As Decimal, discount As Decimal,
                                fee As Decimal, feeRate As Decimal, total As Decimal,
                                cash As Decimal, change As Decimal,
                                paymentMethod As String, refNumber As String)
        Try
            Dim orderDate As String = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")
            Dim receiptsFolder As String = "C:\Users\anthn\Downloads\pen_de_masa_order_receipts"
            If Not Directory.Exists(receiptsFolder) Then
                Directory.CreateDirectory(receiptsFolder)
            End If
            Dim savePath As String = Path.Combine(receiptsFolder, "Receipt_Order" & orderId & ".pdf")

            Dim doc As New Document(New Rectangle(227, 700), 10, 10, 10, 10)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(savePath, FileMode.Create))
            doc.Open()

            Dim fontTitle As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)
            Dim fontNormal As Font = FontFactory.GetFont(FontFactory.HELVETICA, 8)
            Dim fontBold As Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)
            Dim fontSmall As Font = FontFactory.GetFont(FontFactory.HELVETICA, 7)

            ' Header
            Dim title As New Paragraph("Pan de Masa", fontTitle)
            title.Alignment = Element.ALIGN_CENTER
            doc.Add(title)

            Dim subtitle As New Paragraph("Official Receipt", fontNormal)
            subtitle.Alignment = Element.ALIGN_CENTER
            doc.Add(subtitle)

            doc.Add(New Paragraph(" ", fontSmall))
            doc.Add(New Paragraph("Order #: " & orderId.ToString(), fontNormal))
            doc.Add(New Paragraph("Date: " & orderDate, fontNormal))
            doc.Add(New Paragraph("Payment: " & paymentMethod, fontNormal))

            If refNumber <> "" Then
                doc.Add(New Paragraph("Ref #: " & refNumber, fontNormal))
            End If

            doc.Add(New Paragraph("--------------------------------", fontSmall))

            ' Items table
            Dim itemTable As New PdfPTable(4)
            itemTable.WidthPercentage = 100
            itemTable.SetWidths(New Single() {40, 15, 22, 23})

            For Each header As String In {"Product", "Qty", "Price", "Total"}
                Dim cell As New PdfPCell(New Phrase(header, fontBold))
                cell.Border = Rectangle.NO_BORDER
                itemTable.AddCell(cell)
            Next

            For Each item As CartItem In CartItems
                Dim c1 As New PdfPCell(New Phrase(item.ProductName, fontNormal))
                c1.Border = Rectangle.NO_BORDER
                itemTable.AddCell(c1)

                Dim c2 As New PdfPCell(New Phrase(item.Quantity.ToString(), fontNormal))
                c2.Border = Rectangle.NO_BORDER
                itemTable.AddCell(c2)

                Dim c3 As New PdfPCell(New Phrase("P" & item.UnitPrice.ToString("0.00"), fontNormal))
                c3.Border = Rectangle.NO_BORDER
                itemTable.AddCell(c3)

                Dim c4 As New PdfPCell(New Phrase("P" & item.Total.ToString("0.00"), fontNormal))
                c4.Border = Rectangle.NO_BORDER
                itemTable.AddCell(c4)
            Next

            doc.Add(itemTable)
            doc.Add(New Paragraph("--------------------------------", fontSmall))

            ' Totals table
            Dim totalsTable As New PdfPTable(2)
            totalsTable.WidthPercentage = 100
            totalsTable.SetWidths(New Single() {55, 45})

            ' Subtotal
            Dim r1l As New PdfPCell(New Phrase("Subtotal:", fontNormal))
            r1l.Border = Rectangle.NO_BORDER
            totalsTable.AddCell(r1l)
            Dim r1r As New PdfPCell(New Phrase("P" & subtotal.ToString("0.00"), fontNormal))
            r1r.Border = Rectangle.NO_BORDER
            r1r.HorizontalAlignment = Element.ALIGN_RIGHT
            totalsTable.AddCell(r1r)

            ' Discount
            If discount > 0 Then
                Dim r2l As New PdfPCell(New Phrase("Discount (20%):", fontNormal))
                r2l.Border = Rectangle.NO_BORDER
                totalsTable.AddCell(r2l)
                Dim r2r As New PdfPCell(New Phrase("- P" & discount.ToString("0.00"), fontNormal))
                r2r.Border = Rectangle.NO_BORDER
                r2r.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(r2r)
            End If

            ' Fee
            If fee > 0 Then
                Dim r3l As New PdfPCell(New Phrase("Fee (" & (feeRate * 100).ToString("0.#") & "%):", fontNormal))
                r3l.Border = Rectangle.NO_BORDER
                totalsTable.AddCell(r3l)
                Dim r3r As New PdfPCell(New Phrase("P" & fee.ToString("0.00"), fontNormal))
                r3r.Border = Rectangle.NO_BORDER
                r3r.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(r3r)
            End If

            ' Total
            Dim r4l As New PdfPCell(New Phrase("TOTAL:", fontBold))
            r4l.Border = Rectangle.NO_BORDER
            totalsTable.AddCell(r4l)
            Dim r4r As New PdfPCell(New Phrase("P" & total.ToString("0.00"), fontBold))
            r4r.Border = Rectangle.NO_BORDER
            r4r.HorizontalAlignment = Element.ALIGN_RIGHT
            totalsTable.AddCell(r4r)

            ' Cash / Change / Card
            If paymentMethod = "Cash" Then
                Dim r5l As New PdfPCell(New Phrase("Cash:", fontNormal))
                r5l.Border = Rectangle.NO_BORDER
                totalsTable.AddCell(r5l)
                Dim r5r As New PdfPCell(New Phrase("P" & cash.ToString("0.00"), fontNormal))
                r5r.Border = Rectangle.NO_BORDER
                r5r.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(r5r)

                Dim r6l As New PdfPCell(New Phrase("Change:", fontNormal))
                r6l.Border = Rectangle.NO_BORDER
                totalsTable.AddCell(r6l)
                Dim r6r As New PdfPCell(New Phrase("P" & change.ToString("0.00"), fontNormal))
                r6r.Border = Rectangle.NO_BORDER
                r6r.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(r6r)

            ElseIf paymentMethod = "Card" Then
                Dim r5l As New PdfPCell(New Phrase("Card Payment:", fontNormal))
                r5l.Border = Rectangle.NO_BORDER
                totalsTable.AddCell(r5l)
                Dim r5r As New PdfPCell(New Phrase("Approved", fontNormal))
                r5r.Border = Rectangle.NO_BORDER
                r5r.HorizontalAlignment = Element.ALIGN_RIGHT
                totalsTable.AddCell(r5r)
            End If

            doc.Add(totalsTable)
            doc.Add(New Paragraph("--------------------------------", fontSmall))

            ' Footer
            Dim footer As New Paragraph("Thank you for your purchase!", fontNormal)
            footer.Alignment = Element.ALIGN_CENTER
            doc.Add(footer)

            Dim footer2 As New Paragraph("Pan de Masa - Fresh Baked Daily", fontSmall)
            footer2.Alignment = Element.ALIGN_CENTER
            doc.Add(footer2)

            doc.Close()

            MessageBox.Show("Receipt saved as Receipt_Order" & orderId & ".pdf",
                            "Receipt Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("PDF Error: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module