import { NgModule } from '@angular/core'
import { MenubarModule } from "primeng/menubar";
import { MainComponent } from "./main.component";
import { ButtonModule } from 'primeng/button';

@NgModule({
    declarations: [MainComponent],
    imports: [
        MenubarModule,
        ButtonModule
    ]
})
export class MainModule {}
