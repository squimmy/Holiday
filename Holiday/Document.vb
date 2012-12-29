Public NotInheritable Class Document
    Implements INodeContainer

    Private ReadOnly _Contents As List(Of INode)

    Public ReadOnly Containers As Dictionary(Of String, INodeContainer)
    Public ReadOnly Nodes As Dictionary(Of String, INode)

    Public Sub New()
        _Contents = New List(Of INode)()
        Me.Containers = New Dictionary(Of String, INodeContainer)()
        Me.Nodes = New Dictionary(Of String, INode)()
    End Sub

    Public Iterator Function GetLines() As IEnumerable(Of String)
        For Each node In _Contents
            For Each line In node.GetLines(1)
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
