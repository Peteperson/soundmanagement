Imports FileHelpers
<IgnoreFirst(1), _
 IgnoreEmptyLines(), _
 DelimitedRecord("	")> _
Public NotInheritable Class SoundRecord
	Public Creator As String
	Public Library As String
	<FieldNullValue(""), FieldOptional()> Public Year As String
	Public CD As String
	Public Track As Int32
	Public Index As Int32
	<FieldNullValue(""), FieldOptional()> Public Category As String
	<FieldNullValue(""), FieldOptional()> Public SubCategory As String
	Public Description As String
	Public Time As String
	<FieldNullValue(0), FieldOptional()> Public Rating As Int32
	Public Filename As String
	<FieldNullValue(""), FieldOptional()> Public Tags As String
End Class