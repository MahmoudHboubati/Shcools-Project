import { TranslateService } from '@ngx-translate/core';
import { MaterialService } from './../../services/material.service';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from "../../base-components/base.component";

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.css']
})
export class MaterialComponent extends BaseComponent implements OnInit {

  current: {} = {};
  materials: any[] = [];

  constructor(private materialService: MaterialService, translate: TranslateService) {
    super(translate);
  }

  ngOnInit() {
    this.loadAll();
  }

  loadAll() {
    this.materialService.getList().subscribe((listRes) => { this.materials = listRes; });
  }

  addNew(form) {
    this.materialService.add(this.current).subscribe(added => {
      this.materials.push(added);
      form.resetForm();
    });
  }

  delete(item) {
    if (confirm(this.delConfirmMessage) == true) {
      this.materialService.delete(item).subscribe(id => {
        var index = this.materials.map(i => i.id).indexOf(id);
        this.materials.splice(index, 1);
      });
    }
  }
}
