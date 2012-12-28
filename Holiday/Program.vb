Public Module Program
    Public Sub Main(args As String())

    End Sub

    Public Function Fold(input As IEnumerable(Of String)) As IReadOnlyList(Of String)
        Dim document = New Document()

        document.Containers("document") = document

        Dim events = From line In input
                     Select Program.CreateEvent(line)

        For Each evt In events
            evt.Execute(document)
        Next

        Return document.GetLines().ToList()
    End Function

    Public Function CreateEvent(line As String) As IEvent
        Dim eventWordEnd = line.IndexOf(" "c)
        Dim eventWord = line.Substring(0, eventWordEnd)
        Select Case eventWord
            Case "CreateHeading"
                Dim parameters = line.Substring(eventWordEnd + 1).Split({" "c}, 5)
                Dim id = parameters(0)
                Dim level = Integer.Parse(parameters(1))
                Dim parentId = parameters(2)
                Dim position = UInteger.Parse(parameters(3))
                Dim text = parameters(4)
                Return New CreateHeadingEvent(id, level, parentId, position, text)
            Case "CreateParagraph"
                Dim parameters = line.Substring(eventWordEnd + 1).Split({" "c}, 4)
                Dim id = parameters(0)
                Dim parentId = parameters(1)
                Dim position = UInteger.Parse(parameters(2))
                Dim text = parameters(3)
                Return New CreateParagraphEvent(id, parentId, position, text)
            Case "DeleteNode"
                Dim parameters = line.Substring(eventWordEnd + 1).Split({" "c}, 1)
                Dim id = parameters(0)
                Return New DeleteNodeEvent(id)
            Case "MoveNode"
                Dim parameters = line.Substring(eventWordEnd + 1).Split({" "c}, 3)
                Dim id = parameters(0)
                Dim parentId = parameters(1)
                Dim position = UInteger.Parse(parameters(2))
                Return New MoveNodeEvent(id, parentId, position)
            Case Else
                Throw New NotSupportedException(String.Format("Event not supported: {0}", eventWord))
        End Select
    End Function
End Module
