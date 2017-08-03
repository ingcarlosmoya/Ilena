export class PhysicalExam {
    height:number;
    weight:number;
    bmi:number;
    bmiDiagnostic:string;
    bmiClass:string;

    constructor(){
        this.bmi = 0;
        this.bmiClass = '';
        this.bmiDiagnostic = '';
        this.height = 0;
        this.weight = 0;
    }
}
