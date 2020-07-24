
using System.Collections.Generic;

public class FakeStateRepository : IStatesRepository
{
    public List<State> GetStates()
    {
        return new List<State>(){
            new State() { Name = "Virginia", Abbreviation = "VA"},
            new State() { Name = "Texas", Abbreviation = "TX"},
            new State() { Name = "Washington", Abbreviation = "WA"}
        };
    }
}