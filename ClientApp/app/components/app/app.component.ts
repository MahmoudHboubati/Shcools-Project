import { TranslateService } from '@ngx-translate/core';
import { Component } from '@angular/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private translateService: TranslateService) {
        translateService.setDefaultLang('ar');
        translateService.use('ar');
    }
}
