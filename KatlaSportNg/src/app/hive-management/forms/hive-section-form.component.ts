import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSection } from '../models/hive-section'
import { HiveSectionService} from '../services/hive-section.service'

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  hiveSection = new HiveSection(0, "", "", 0, false, "");
  existed = false;
  hiveId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveId = p['hiveId'];
      if (p['id'] === undefined) return;
      this.hiveSectionService.getHiveSection(p['id']).subscribe(s => this.hiveSection = s);
      this.existed = true;
    })
  }

  navigateToSections() {
    if (this.hiveId === undefined){
      this.hiveId = this.hiveSection.storeHiveId;
    }
    this.router.navigate([`/hive/${this.hiveId}/sections`]);
  }

  onCancel() {
    this.navigateToSections();
  }

  onSubmit(){
    this.hiveSection.storeHiveId = this.hiveId;
    if (this.existed){
      this.hiveSectionService.updateHiveSection(this.hiveSection).subscribe(() => this.navigateToSections());
    }
    else{
      this.hiveSectionService.addHiveSection(this.hiveSection).subscribe(() => this.navigateToSections());
    }
  }

  onDelete(){
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, true).subscribe(() => this.hiveSection.isDeleted = true);
  }

  onUndelete(){
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id,false).subscribe(()=>this.hiveSection.isDeleted = false);
  }

  onPurge(){
    this.hiveSectionService.deleteHiveSection(this.hiveSection.id).subscribe(() => this.navigateToSections());
  }
}
