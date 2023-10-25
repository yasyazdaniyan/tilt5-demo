using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePointer : MonoBehaviour
{
    LineRenderer lineRenderer;

    List<Machine> machines = new List<Machine>();
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lineRenderer.positionCount == 0)
            return;

        Vector3 endPoint = lineRenderer.GetPosition(lineRenderer.positionCount - 1);

        Collider[] colliders = Physics.OverlapSphere(endPoint, 0.1f);
        Machine machine = null;

        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Machine")
            {
                machine = collider.GetComponentInParent<Machine>();

                if(!machines.Contains(machine))
                    machines.Add(machine);

                if(!machine.GetIsActive())
                {
                    machine.ToggleCanvas();
                }

                foreach (Machine otherMachine in machines)
                {
                    if (otherMachine != machine && otherMachine.GetIsActive())
                    {
                        otherMachine.ToggleCanvas();
                    }
                }
            }
        }

        if(machine == null)
        {
            foreach (Machine otherMachine in machines)
            {
                if (otherMachine.GetIsActive())
                {
                    otherMachine.ToggleCanvas();
                }
            }
        }
    }
}
