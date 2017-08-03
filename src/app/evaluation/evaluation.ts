import { Person } from './../people/person';
import { Habits } from './../people/habits';
import { PhysicalExam } from './../people/physical-exam';
import { Routine } from './../routine/routine';


export class Evaluation {
    person: Person;
    physicalExam: PhysicalExam;
    habits: Habits;
    routines: Routine[];

    constructor()
    {
        this.person = new Person();
        this.habits = new Habits();
        this.physicalExam = new PhysicalExam();
        this.routines = new Array();
     }
}
