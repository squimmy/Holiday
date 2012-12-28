Public NotInheritable Class MoveNodeEvent
    Implements IEvent

    Private ReadOnly _Id As String
    Private ReadOnly _ParentId As String
    Private ReadOnly _Position As UInteger

    Public Sub New(id As String, parentId As String, position As UInteger)
        _Id = id
        _ParentId = parentId
        _Position = position
    End Sub

    Public Sub Execute(document As Document) Implements IEvent.Execute
        Dim node = document.Nodes(_Id)

        node.Parent.Contents.Remove(node)

        Dim parent = document.Containers(_ParentId)
        parent.Contents.Insert(_Position, node)
        node.Parent = parent
    End Sub
End Class
