Public Interface INode
    Property Parent As INodeContainer
    Function GetLines() As IEnumerable(Of String)
End Interface
