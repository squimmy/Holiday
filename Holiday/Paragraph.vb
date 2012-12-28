Public NotInheritable Class Paragraph
    Implements INode

    Public Text As String

    Public Property Parent As INodeContainer Implements INode.Parent

    Public Iterator Function GetLines() As IEnumerable(Of String) Implements INode.GetLines
        Yield Text
    End Function
End Class
