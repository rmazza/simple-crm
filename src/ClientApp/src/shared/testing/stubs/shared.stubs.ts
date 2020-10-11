import { ConfirmationService } from 'primeng/api';

const confirmationServiceStub = () => ({
    confirm: () => ({
        message: "",
        accept: () => ({})
    })
});

const getBaseUrlStub = () => "/";

export const ConfirmationServiceStubProvider = { provide: ConfirmationService, useFactory: confirmationServiceStub };
export const GetBaseUrlStubProvider = { provide: 'BASE_URL', useFactory: getBaseUrlStub };