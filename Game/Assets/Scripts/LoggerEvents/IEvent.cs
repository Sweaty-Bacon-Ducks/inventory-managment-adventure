using System.Collections;

public interface IEvent
{
	IEnumerator EventAction(params object[] obj);
}
