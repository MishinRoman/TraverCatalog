
import { useLayoutEffect, useState } from "react";

export const useTheme=()=>{
    const [theme, setTheme] = useState<string>(localStorage.theme);
    useLayoutEffect(() => {
    
     
      document.documentElement.setAttribute("class",theme);
      
    }, [theme])
    return {theme, setTheme}
}