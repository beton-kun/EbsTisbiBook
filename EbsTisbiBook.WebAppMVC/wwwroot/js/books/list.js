$(document).ready(function () {
	$("#authors-button-add").click(function (e) {
		e.preventDefault();
		$(".authors-container").append(`<select name="author" asp-items="@Model.FilterViewModel.Authors"></select>`);
	})
	$("#authors-button-remove").click(function (e) {
		e.preventDefault();
		$(".authors-container select").last().remove();
	})
});
