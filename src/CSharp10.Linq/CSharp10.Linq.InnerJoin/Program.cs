using CSharp10.Linq.InnerJoin;

SamplesViewModel vm = new();

// Call Sample Method
var result = vm.LeftOuterJoinMethod();

// Display Results
vm.Display(result);