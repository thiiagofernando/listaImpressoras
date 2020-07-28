Imports System.Drawing.Printing

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each nomeImpressora In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ListBox1.Items.Add(nomeImpressora)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        'Verifica se existe um item selecionado no ListBox'
        If ListBox1.SelectedIndex <> -1 Then
            Dim aConfiguracoes As New PrinterSettings()
            Dim aResolucao As New PrinterResolution
            Dim aTamanhoPapel As New PaperSize
            aConfiguracoes.PrinterName = CType(ListBox1.SelectedItem, String)
            'Limpa o ListBox'
            ListBox2.Items.Clear()
            'Lista as resoluções suportadas'
            For Each aResolucao In aConfiguracoes.PrinterResolutions
                ListBox2.Items.Add(aResolucao.ToString)
            Next
            'Limpa o ListBox'
            ListBox3.Items.Clear()
            'Lista os Tamanhos de papel suportado'
            For Each aTamanhoPapel In aConfiguracoes.PaperSizes
                ListBox3.Items.Add(aTamanhoPapel.ToString)
            Next
            'Insere no textBox a configuração padrão da impressora'
            TextBox1.Text = aConfiguracoes.DefaultPageSettings.ToString
        End If
    End Sub
End Class
