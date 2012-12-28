Public NotInheritable Class DeleteNodeEvent
    Implements IEvent

    Private ReadOnly _Id As String

    Public Sub New(id As String)
        _Id = id
    End Sub

    Public Sub Execute(document As Document) Implements IEvent.Execute
        Dim node = document.Nodes(_Id)
        node.Parent.Contents.Remove(node)
    End Sub
End Class
