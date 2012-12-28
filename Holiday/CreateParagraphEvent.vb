Public NotInheritable Class CreateParagraphEvent
    Implements IEvent

    Private ReadOnly _Id As String
    Private ReadOnly _ParentId As String
    Private ReadOnly _Position As UInteger
    Private ReadOnly _Text As String

    Public Sub New(id As String, parentId As String, position As UInteger, text As String)
        _Id = id
        _ParentId = parentId
        _Position = position
        _Text = text
    End Sub

    Public Sub Execute(document As Document) Implements IEvent.Execute
        Dim paragraph = New Paragraph() With {.Text = _Text}

        Dim parent = document.Containers(_parentId)
        parent.Contents.Insert(_Position, paragraph)
        paragraph.Parent = parent

        document.Nodes(_Id) = paragraph
    End Sub
End Class
