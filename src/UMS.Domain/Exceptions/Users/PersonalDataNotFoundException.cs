namespace UMS.Domain.Exceptions.Users;

public class PersonalDataNotFoundException : NotFoundException
{
	public PersonalDataNotFoundException()
	{
		ExceptionMessage = "User not found !";
	}
}
