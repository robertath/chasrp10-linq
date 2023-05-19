using CSharp10.Linq.OrderBy;

SamplesViewModel vm = new();

// Call Sample Method
var result = vm.OrderByTwoFieldsQuery();

// Display Results
vm.Display(result);