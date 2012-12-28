Public NotInheritable Class CreateHeadingEvent
    Implements IEvent

    Private ReadOnly _Id As String
    Private ReadOnly _Level As Integer
    Private ReadOnly _ParentId As String
    Private ReadOnly _Position As UInteger
    Private ReadOnly _Text As String

    Public Sub New(id As String, level As Integer, parentId As String, position As UInteger, text As String)
        _Id = id
        _Level = level
        _ParentId = parentId
        _Position = position
        _Text = text
    End Sub

    Public Sub Execute(document As Document) Implements IEvent.Execute
        Dim heading = New Heading() With {.Level = _Level, .Text = _Text}

        Dim parent = document.Containers(_ParentId)
        parent.Contents.Insert(_Position, heading)
        heading.Parent = parent

        document.Containers(_Id) = heading
        document.Nodes(_Id) = heading
    End Sub
End Class
