using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSides : MonoBehaviour
{
    public bool P1check;
    SlidingTable st;

    // Use this for initialization
    void Start()
    {
        st = gameObject.transform.parent.gameObject.GetComponent<SlidingTable>();
        st.P1active = false;
        st.P2active = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1" && P1check)
        {
            st.P1active = true;
        }
        else if (col.gameObject.tag == "Player2" && !P1check)
        {
            st.P2active = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        st.P1active = false;
        st.P2active = false;
    }
}
