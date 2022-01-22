import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SprintManagerClient';
  items: MenuItem[];

  ngOnInit() {
    this.items = [
      {
        label: 'New Sprint',
        icon: 'pi pi-fw pi-plus',
      },
      {
        label: 'New Task',
        icon: 'pi pi-fw pi-plus',
      }
    ];
  }

}
