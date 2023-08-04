
const customPopup = document.getElementById('customPopup');
const confirmButton = document.getElementById('confirmButton');
const cancelButton = document.getElementById('cancelButton');

function showCustomPopup() {
	customPopup.style.display = 'block';
}

function hideCustomPopup() {
	customPopup.style.display = 'none';
}

confirmButton.addEventListener('click', function () {
	// Trigger the form submission when "Yes" is clicked
	document.querySelector('form').submit();
});

cancelButton.addEventListener('click', hideCustomPopup);

// Add this event listener to your existing submit button
document.querySelector('form').addEventListener('submit', function (e) {
	e.preventDefault(); // Prevent the default form submission
	showCustomPopup();
});
