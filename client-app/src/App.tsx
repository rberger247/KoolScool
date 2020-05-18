import React, { Fragment, useState, useEffect } from "react";
import "./App.css";
import axios from "axios";
import { IStudent } from "./App/models/student";
import { List, Container } from "semantic-ui-react";
import { useDrag, DndProvider } from "react-dnd";
import  Backend from "react-dnd-html5-backend";
import {sample} from "./App/components/sample";
import Example from "../src/App/components/example";


export const App = () => {
  const [student, setStudent] = useState<IStudent[]>([]);
  // const [{ isDragging }, drag] = useDrag({
  //   item: { type: sample.STUDENT },
  //   collect: monitor => ({
  //     isDragging: !!monitor.isDragging(),
  //   }),
  // })

  useEffect(() => {
    axios
      .get<IStudent[]>("http://localhost:5000/api/student")
      .then((response) => {
        setStudent(response.data);
        console.log(response.data);
      });
  }, []);
  return (
    
    <Fragment>

{/* <DndProvider backend={Backend}>
					<Example />
				</DndProvider> */}
    <div >
   
    <Container>

      <List >
      {student.map((s) => (
         
         <List.Item key={s.studentID}>{s.firstName}</List.Item>
         
       ))}
        {student.map((s) => (
         
          <List.Item key={s.studentID}>{s.lastName}</List.Item>
          
        ))}

      </List>
   
      </Container>
     
    </div>
 
    </Fragment>
  
  );
};

export default  App;
