//document.addEventListener("DOMContentLoaded", () => {

//    type PopUpType = "success" | "error";

//    interface AlertOptions {
//        messageBody: string;
//        redirectUrl?: string;
//        func?: () => void;
//    }

//    function alertMessage(
//        popupType: PopUpType,
//        options: AlertOptions
//    ): void {

//        let cssClass = "alert-info";

//        if (popupType === "success") cssClass = "alert-success";
//        if (popupType === "error") cssClass = "alert-danger";

//        const alertHtml = `
//            <div class="alert ${cssClass} alert-dismissible fade show" role="alert">
//                ${options.messageBody}
//                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
//            </div>
//        `;

//        const container = document.getElementById("alert-container");

//        if (container) {
//            container.innerHTML = alertHtml;
//        }
//    }

//    const form = document.getElementById("bookingForm") as HTMLFormElement | null;

//    if (form) {
//        form.addEventListener("submit", async (e: Event) => {
//            e.preventDefault();

//            const formData = new FormData(form);

//            const response = await fetch("/Book", {
//                method: "POST",
//                body: formData
//            });

//            const result: { success: boolean; message: string } = await response.json();

//            if (result.success) {
//                alertMessage("success", {
//                    messageBody: result.message
//                });

//                form.reset();
//            } else {
//                alertMessage("error", {
//                    messageBody: result.message
//                });
//            }
//        });
//    }
//});