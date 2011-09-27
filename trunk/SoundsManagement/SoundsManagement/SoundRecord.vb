Imports FileHelpers
<IgnoreFirst(1), _
 IgnoreEmptyLines(), _
 DelimitedRecord("	")> _
Public NotInheritable Class SoundRecord

    Private mCreator As String
    Public Property Creator As String
        Get
            If mCreator = "" Then Return "-"
            Return mCreator
        End Get
        Set(value As String)
            mCreator = value
        End Set
    End Property

    Private mLibrary As String
    Public Property Library As String
        Get
            If mLibrary = "" Then Return "-"
            Return mLibrary
        End Get
        Set(value As String)
            mLibrary = value
        End Set
    End Property

    Public Year As String

    Private mCD As String
    Public Property CD As String
        Get
            If mCD = "" Then Return "-"
            Return mCD
        End Get
        Set(value As String)
            mCD = value
        End Set
    End Property

    <FieldNullValue(0)> Public Track As Int32
    <FieldNullValue(0)> Public Index As Int32

    Private mCategory As String
    Public Property Category As String
        Get
            If mCategory = "" Then Return "-"
            Return mCategory
        End Get
        Set(value As String)
            mCategory = value
        End Set
    End Property

    Private mSubCategory As String
    Public Property SubCategory As String
        Get
            If mSubCategory = "" Then Return "-"
            Return mSubCategory
        End Get
        Set(value As String)
            mSubCategory = value
        End Set
    End Property

    Public Description As String
    Public Time As String
    <FieldNullValue(0)> Public Rating As Int32

    Private mFilename As String
    Public Property Filename As String
        Get
            Return mFilename
        End Get
        Set(value As String)
            mFilename = value
        End Set
    End Property

    Public Tags As String
End Class