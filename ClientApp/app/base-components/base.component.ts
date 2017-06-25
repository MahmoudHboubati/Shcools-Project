import { TranslateService } from '@ngx-translate/core';
export abstract class BaseComponent {

    protected readonly translate: TranslateService;
    delConfirmMessage: string;

    constructor(translate: TranslateService) {
        this.translate = translate;
    }

    protected loadTranslations() {
        this.translate.get('trGenDelelteConfirmMessage').subscribe((res: string) => {
            this.delConfirmMessage = res;
        });
    }
}