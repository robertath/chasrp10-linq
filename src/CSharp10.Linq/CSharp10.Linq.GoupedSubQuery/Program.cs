using CSharp10.Linq.GoupedSubQuery;

SamplesViewModel vm = new();

// Call Sample Method
var result = vm.GroupByDistinctMethod();

// Display Results
vm.Display(result);