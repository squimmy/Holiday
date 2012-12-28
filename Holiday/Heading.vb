Public NotInheritable Class Heading
    Implements INode
    Implements INodeContainer

    Private ReadOnly _Contents As New List(Of INode)()

    Public Level As Integer
    Public Text As String

    Public Property Parent As INodeContainer Implements INode.Parent

    Public Iterator Function GetLines() As IEnumerable(Of String) Implements INode.GetLines
        Yield New String("#"c, Level) & Text
        For Each node In _Contents
            For Each line In node.GetLines()
                Yield line
            Next
        Next
    End Function

    Public ReadOnly Property Contents As List(Of INode) Implements INodeContainer.Contents
        Get
            Return _Contents
        End Get
    End Property
End Class
