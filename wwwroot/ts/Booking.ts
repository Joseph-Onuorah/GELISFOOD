const form = document.getElementById("bookingForm") as HTMLFormElement;

form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const formData = new FormData(form);

    const response = await fetch("/Book", {
        method: "POST",
        body: formData
    });

    if (response.ok) {
        alert("Booking submitted successfully!");
        form.reset();
    } else {
        alert("Error submitting booking.");
    }
});
