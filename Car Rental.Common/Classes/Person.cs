using Car_Rental.Common.Interfaces;
using System.Globalization;

namespace Car_Rental.Common.Classes;

public class Person : IPerson
{
	public int Id { get; init; }
	public int Ssn { get; init; }
	public string FirstName { get; init; }
	public string LastName { get; init; }

	public Person(int id, int ssn, string firstname, string lastname) =>
		(Id, Ssn, FirstName, LastName) = (id, ssn, firstname, lastname);
}
