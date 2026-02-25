"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
alert("JS Loaded");
function alertMessage(type, options) {
    let cssClass = "alert-info";
    if (type === "success")
        cssClass = "alert-success";
    if (type === "error")
        cssClass = "alert-danger";
    const alertHtml = `
        <div class="alert ${cssClass} alert-dismissible fade show" role="alert">
            ${options.messageBody}
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </div>
    `;
    const container = document.getElementById("alert-container");
    if (container) {
        container.innerHTML = alertHtml;
    }
    if (options.redirectUrl) {
        setTimeout(() => {
            window.location.href = options.redirectUrl;
        }, 2000);
    }
    if (options.func) {
        options.func();
    }
}
const form = document.getElementById("bookingForm");
if (form) {
    form.addEventListener("submit", (e) => __awaiter(void 0, void 0, void 0, function* () {
        var _a;
        e.preventDefault();
        console.log("JS is working"); // 👈 add this
        const formData = new FormData(form);
        const tokenInput = document.querySelector('input[name="__RequestVerificationToken"]');
        const response = yield fetch("/Book", {
            method: "POST",
            headers: {
                "RequestVerificationToken": (_a = tokenInput === null || tokenInput === void 0 ? void 0 : tokenInput.value) !== null && _a !== void 0 ? _a : ""
            },
            body: formData
        });
        const result = yield response.json();
        if (result.success) {
            alertMessage("success", {
                messageBody: result.message
            });
            form.reset();
        }
        else {
            alertMessage("error", {
                messageBody: result.message || "Error submitting booking."
            });
        }
    }));
}
//# sourceMappingURL=Booking.js.map