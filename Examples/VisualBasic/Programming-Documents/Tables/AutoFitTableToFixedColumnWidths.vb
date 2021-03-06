﻿Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Diagnostics

Imports Aspose.Words
Imports Aspose.Words.Tables

Public Class AutoFitTableToFixedColumnWidths
    Public Shared Sub Run()
        ' ExStart:AutoFitTableToFixedColumnWidths
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_WorkingWithTables()
        Dim fileName As String = "TestFile.doc"
        ' Open the document
        Dim doc As New Document(dataDir & fileName)

        Dim table As Table = CType(doc.GetChild(NodeType.Table, 0, True), Table)

        ' Disable autofitting on this table.
        table.AutoFit(AutoFitBehavior.FixedColumnWidths)

        dataDir = dataDir & RunExamples.GetOutputFilePath(fileName)
        ' Save the document to disk.
        doc.Save(dataDir)
        ' ExEnd

        Debug.Assert(doc.FirstSection.Body.Tables(0).PreferredWidth.Type = PreferredWidthType.Auto, "PreferredWidth type is not auto")
        Debug.Assert(doc.FirstSection.Body.Tables(0).PreferredWidth.Value = 0, "PreferredWidth value is not 0")
        Debug.Assert(doc.FirstSection.Body.Tables(0).FirstRow.FirstCell.CellFormat.Width = 69.2, "Cell width is not correct.")
        ' ExEnd:AutoFitTableToFixedColumnWidths
        Console.WriteLine(vbNewLine & "Auto fit tables to fixed width successfully." + vbNewLine + "File saved at " + dataDir)
    End Sub
End Class
