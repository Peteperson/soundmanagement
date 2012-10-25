Public Class FileExistance
	Public Sub New(fFound As Boolean, fPath As String)
		FileFound = fFound
		FilePath = fPath
	End Sub
	Public Property FileFound As Boolean
	Public Property FilePath As String
End Class
