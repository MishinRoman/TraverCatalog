import React from 'react'
import {AiOutlineLoading3Quarters} from 'react-icons/ai'




type Props = {}

const Loading = (props: Props) => {
  return (
    <svg
    className={"animate-spin h-18 w-18 rounded-full"}
    viewBox="0 0 16 16"
  >
   
   <AiOutlineLoading3Quarters />
  </svg>
  )
}

export default Loading