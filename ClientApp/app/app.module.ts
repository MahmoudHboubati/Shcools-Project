import { MaterialService } from './services/material.service';
import { StudentClassService } from './services/student-class.service';
import { ClassService } from './services/class.service';
import { StudyingYearService } from './services/studying-year.service';
import { GradeService } from './services/grade.service';
import { StudentRegistrationService } from './services/student-registration.service';
import { StudentReginstrationComponent } from './components/student-reginstration/student-reginstration.component';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { Http } from '@angular/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { StudentService } from './services/student.service';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { StudentFormComponent } from './components/student-form/student-form.component';

import { FormsModule } from '@angular/forms';
import { GradeFormComponent } from './components/grade-form/grade-form.component';
import { StudyingYearComponent } from './components/studying-year/studying-year.component';
import { ClassComponent } from './components/class/class.component';
import { StudentClassComponent } from './components/student-class/student-class.component';
import { ClassStudentsComponent } from './components/class-students/class-students.component';

import * as components from './components/custom/index';
import { MaterialComponent } from './components/material/material.component';
const allComponents = Object.keys(components).map(k => components[k]);

// AoT requires an exported function for factories
export function HttpLoaderFactory(http: Http) {
    return new TranslateHttpLoader(http, './i18n/', '.json');
}

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        StudentFormComponent,
        StudentReginstrationComponent,
        GradeFormComponent,
        StudyingYearComponent,
        ClassComponent,
        StudentClassComponent,
        ClassStudentsComponent,
        allComponents,
        MaterialComponent
    ],
    exports: allComponents,
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'students/new', component: StudentFormComponent },
            { path: 'students/register', component: StudentReginstrationComponent },
            { path: 'studyingYear/new', component: StudyingYearComponent },
            { path: 'studentclass/new', component: StudentClassComponent },

            { path: 'class/new', component: ClassComponent },
            { path: 'class/editStudents/:classId', component: ClassStudentsComponent },

            { path: 'grades/new', component: GradeFormComponent },
            { path: 'material/new', component: MaterialComponent },

            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [Http]
            }
        })
    ],
    providers: [StudentService, StudentRegistrationService, GradeService, StudyingYearService, ClassService, StudentClassService, MaterialService]
})
export class AppModule {
}
