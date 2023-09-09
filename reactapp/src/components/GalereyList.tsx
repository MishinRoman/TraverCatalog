import React, { useState } from 'react'
import { IMedia } from '../interfaces/app.interfaces'

type Props = {
    images:IMedia[]
}

const GalereyList = (props: Props) => {
    const [filePath, setFilePath]=useState<string>();
    const [count, setCount] = useState<number>(0);
        props.images.map(i=>setFilePath(i.physicalPath+i.name))

    // const listToLeft=()=>{
    //     if(count<props.images.length)
    //    setCount(count+1);
    // }
    // const listToRigth=()=>{
        
    //    setCount(count-1);
    // }

  return (
   <div>
    
    {/* <button onClick={listToLeft}>+</button> */}
     <img src={filePath} title={filePath}></img>
     {/* <button onClick={listToRigth}>-</button> */}
   </div>
  )
}

export default GalereyList