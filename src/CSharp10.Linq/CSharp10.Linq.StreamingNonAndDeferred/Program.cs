using CSharp10.Linq.StreamingNonAndDeferred;

SamplesViewModel vm = new();

// Call Sample Method
var result = vm.UsingYield();

// Display Results
vm.Display(result);