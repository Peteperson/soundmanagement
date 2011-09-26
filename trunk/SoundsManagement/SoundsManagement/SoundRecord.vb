Imports FileHelpers

<IgnoreFirst(1), IgnoreEmptyLines(), DelimitedRecord("	")> _
Public NotInheritable Class SoundRecord
    Public Creator As String
    Public Library As String
    Public Year As String
    Public CD As String
    Public Track As Int16
    Public Index As Int16
    Public Category As String
    Public SubCategory As String
    Public Description As String
    Public Time As String
    <FieldNullValue(0)> Public Rating As Int32
    Public Filename As String
    Public Tags As String
End Class