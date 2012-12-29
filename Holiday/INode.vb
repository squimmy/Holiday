Public Interface INode
    Property Parent As INodeContainer
    Function GetLines(headingLevel As Integer) As IEnumerable(Of String)
End Interface
